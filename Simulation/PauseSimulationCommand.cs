namespace Simulation
{
    internal class PauseSimulationCommand : ICommand
    {
        private readonly Object _printLock;

        internal PauseSimulationCommand(Object printLock)
        {
            _printLock = printLock;
        }

        public void Execute()
        {
            lock (_printLock)
            {
                if (Launcher.IsSimulationStarted)
                {
                    if (!Launcher.IsPaused)
                    {
                        Launcher.IsPaused = true;
                        Console.WriteLine("Симуляция приостановлена.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nВы уже находитесь в паузе!\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nОшибка! Сначала запустите симуляцию!\n");
                }
            }
        }
    }
}
