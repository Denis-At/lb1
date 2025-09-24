﻿using System;
namespace Task3;
public class Program
{
    public static string ClassifyAge(int age)
    {
        if (age < 0 || age > 120)
            return "Нереальний вік";
        else if (age < 12)
            return "Ви дитина";
        else if (age <= 17)
            return "Підліток";
        else if (age <= 59)
            return "Дорослий";
        else
            return "Пенсіонер";
    }

    public static void Main(string[] args)
    {
        Console.Write("Введіть ваш вік: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(ClassifyAge(age));
    }
}
