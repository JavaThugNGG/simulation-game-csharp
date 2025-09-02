namespace Simulation
{
    internal class Menu
    {
        private readonly object _printLock;
        private readonly ICommand _startCommand;
        private readonly ICommand _pauseCommand;
        private readonly ICommand _resumeCommand;

        internal Menu(object printLock, ICommand startCommand, ICommand pauseCommand, ICommand resumeCommand)
        {
            _printLock = printLock;
            _startCommand = startCommand;
            _pauseCommand = pauseCommand;
            _resumeCommand = resumeCommand;
        }

        internal void RunMenu()
        {
            lock (_printLock)
            {
                while (!Launcher.IsExit)
                {
                    PrintMenuOptions();

                    int choice = GetValidChoice();

                    if (Launcher.IsExit)
                    {
                        break;
                    }

                    switch (choice)
                    {
                        case 1:
                            _startCommand.Execute();
                            break;
                        case 2:
                            _pauseCommand.Execute();
                            break;
                        case 3:
                            _resumeCommand.Execute();
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Введите цифру от 1 до 3!");
                            break;
                    }
                }
            }
        }

        private void PrintMenuOptions()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Запуск симуляции");
            Console.WriteLine("2 - Пауза");
            Console.WriteLine("3 - Продолжить");
        }

        private int GetValidChoice()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    if (choice is >= 1 and <= 3)
                    {
                        return choice;
                    }

                    Console.WriteLine("Неверный выбор. Введите число от 1 до 3.");
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите корректное число.");
                }
            }
        }
    }
}
