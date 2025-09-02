namespace Simulation
{
    internal class ResumeSimulationCommand : ICommand
    {
        private readonly object _printLock;
        private readonly object _pauseLock;

        internal ResumeSimulationCommand(object printLock, object pauseLock)
        {
            _printLock = printLock;
            _pauseLock = pauseLock;
        }

        public void Execute()
        {
            if (Launcher.IsPaused)
            {
                lock (_printLock)
                {
                    lock (_pauseLock)
                    {
                        Launcher.IsPaused = false;
                        Monitor.Pulse(_pauseLock);
                        Console.WriteLine("Симуляция продолжена.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nОшибка! Вы уже вышли из паузы!\n");
            }
        }
    }
}
