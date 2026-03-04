using System;

namespace PracticalWork1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Оберіть завдання для перевірки (1-6):");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": MathCalculator.Run(); break;
                case "2": Notifications.Run(); break;
                case "3": ListFiltering.Run(); break;
                case "4": ListFiltering.Run(); break; 
                case "5": LoggerSystem.Run(); break;
                case "6": TextValidator.Run(); break;
                default: Console.WriteLine("Вихід..."); break;
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення.");
            Console.ReadKey();
        }
    }
}
