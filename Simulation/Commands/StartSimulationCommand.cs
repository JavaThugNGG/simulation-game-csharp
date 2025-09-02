namespace Simulation.Commands
{
    internal class StartSimulationCommand : ICommand
    {
        private readonly Thread _simulationThread;

        internal StartSimulationCommand(Thread simulationThread)
        {
            _simulationThread = simulationThread;
        }

        public void Execute()
        {
            if (!Launcher.IsSimulationStarted)
            {
                _simulationThread.Start();
                Launcher.IsSimulationStarted = true;
            }
            else
            {
                Console.WriteLine("\nОшибка! Симуляция уже запущена!\n");
            }
        }
    }
}
