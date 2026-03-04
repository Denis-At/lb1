using System;

namespace PracticalWork1
{
    public delegate double MathOperation(double x, double y);

    public static class MathCalculator
    {
        public static void Run()
        {
            Console.WriteLine("--- Завдання 1 & 4: Калькулятор ---");

            MathOperation op = Add;
            Console.WriteLine($"Додавання (10 + 5): {op(10, 5)}");

            op = Subtract;
            Console.WriteLine($"Віднімання (10 - 5): {op(10, 5)}");

            Func<double, double, double> funcOp = Multiply;
            Console.WriteLine($"Множення через Func (10 * 5): {funcOp(10, 5)}");
        }

        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b) => b != 0 ? a / b : 0;
    }
}