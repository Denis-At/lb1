using System;

namespace PracticalWork1
{
    public delegate bool Validator(string text);

    public static class TextValidator
    {
        public static void Run()
        {
            Console.WriteLine("--- Завдання 6: Валідатор ---");

            var passVal = GetValidator(8);
            var loginVal = GetValidator(3);

            Console.WriteLine($"Логін 'User' (мінімум 3): {loginVal("User")}");
            Console.WriteLine($"Пароль '123' (мінімум 8): {passVal("123")}");
        }

        public static Validator GetValidator(int minLength)
        {
            return s => s.Length >= minLength;
        }
    }
}