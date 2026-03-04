using System;

namespace PracticalWork1
{
    public class Logger
    {
        public Action<string> LogHandler;

        public void Log(string message)
        {
            LogHandler?.Invoke(message);
        }
    }

    public static class LoggerSystem
    {
        public static void Run()
        {
            Console.WriteLine("--- Завдання 5: Логування ---");
            Logger logger = new Logger();

            logger.LogHandler = msg => Console.WriteLine($"Консоль: {msg}");
            logger.Log("Система активна");

            logger.LogHandler = msg => Console.WriteLine($"LOG: {msg.ToUpper()}");
            logger.Log("Помилка доступу");
        }
    }
}