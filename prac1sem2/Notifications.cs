using System;

namespace PracticalWork1
{
    public delegate void NotificationHandler(string message);

    public static class Notifications
    {
        public static void Run()
        {
            Console.WriteLine("--- Завдання 2: Мультикастинг ---");

            NotificationHandler handler = SendEmail;
            handler += SendSMS;

            handler("Ваше замовлення оброблено!");
        }

        public static void SendEmail(string msg) => Console.WriteLine($"Email sent: {msg}");
        public static void SendSMS(string msg) => Console.WriteLine($"SMS sent: {msg}");
    }
}