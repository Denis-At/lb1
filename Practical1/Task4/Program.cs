using System;
namespace Task4;
public class Program
{
    public static bool IsValidTriangle(double a, double b, double c)
    {
        return a > 0 && b > 0 && c > 0 &&
               a + b > c && a + c > b && b + c > a;
    }

    public static double GetPerimeter(double a, double b, double c)
    {
        return a + b + c;
    }

    public static double GetArea(double a, double b, double c)
    {
        double p = GetPerimeter(a, b, c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public static string GetTriangleType(double a, double b, double c)
    {
        if (a == b && b == c) return "рівносторонній";
        if (a == b || b == c || a == c) return "рівнобедрений";
        double a2 = a * a, b2 = b * b, c2 = c * c;
        if (Math.Abs(a2 + b2 - c2) < 1e-9 ||
            Math.Abs(a2 + c2 - b2) < 1e-9 ||
            Math.Abs(b2 + c2 - a2) < 1e-9)
            return "прямокутний";
        return "довільний";
    }

    public static void Main(string[] args)
    {
        Console.Write("Введіть сторону a: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть сторону b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть сторону c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        if (IsValidTriangle(a, b, c))
        {
            Console.WriteLine("Периметр: " + GetPerimeter(a, b, c));
            Console.WriteLine("Площа: " + GetArea(a, b, c));
            Console.WriteLine("Тип: " + GetTriangleType(a, b, c));
        }
        else
        {
            Console.WriteLine("Трикутник не існує!");
        }
    }
}
