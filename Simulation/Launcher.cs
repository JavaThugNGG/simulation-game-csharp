namespace Simulation
{
    internal class Launcher
    {
        private static readonly object _pauseLock = new object();
        private static readonly object _printLock = new object();

        internal static bool IsSimulationStarted { get; set; } = false;
        internal static bool IsExit { get; set; } = false;
        internal static bool IsPaused { get; set; } = false;
        internal static bool IsSimulationEnd { get; set; } = false;

        internal static void Main(string[] args)
        {
            SimulationManager simulationManager = new SimulationManager();
            simulationManager.InitializeSimulation();
            Thread simulationThread = CreateSimulationThread(simulationManager);

            ICommand startCommand = new StartSimulationCommand(simulationThread);
            ICommand pauseCommand = new PauseSimulationCommand(_printLock);
            ICommand resumeCommand = new ResumeSimulationCommand(_printLock, _pauseLock);

            Menu menu = new Menu(_printLock, startCommand, pauseCommand, resumeCommand);
            menu.RunMenu();
        }

        private static Thread CreateSimulationThread(SimulationManager simulationManager)
        {
            return new Thread(() =>
            {
                while (!IsSimulationEnd)
                {
                    lock (_pauseLock)
                    {
                        try
                        {
                            while (IsPaused)
                            {
                                Monitor.Wait(_pauseLock);
                            }
                        }
                        catch (ThreadInterruptedException)
                        {
                            Thread.CurrentThread.Interrupt();
                            return;
                        }
                    }

                    if (!IsSimulationEnd)
                    {
                        simulationManager.StartSimulation();
                    }

                    try
                    {
                        Thread.Sleep(1200);
                    }
                    catch (ThreadInterruptedException)
                    {
                        Console.WriteLine("Поток simulationThread был прерван во время сна!");
                        Thread.CurrentThread.Interrupt();
                        return;
                    }

                    IsSimulationEnd = simulationManager.IsEnd;
                }

                simulationManager.PrintLast();
                IsExit = true;
                Console.WriteLine("Симуляция закончена! Введите цифру от 1 до 3 для выхода");
            });
        }
    }
}
