using System;
using System.Collections.Generic;

namespace PracticalWork1
{
    public delegate bool FilterPredicate(int number);

    public static class ListFiltering
    {
        public static void Run()
        {
            Console.WriteLine("--- Завдання 3 & 4: Фільтрація ---");
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.Write("Парні числа: ");
            FilterArray(numbers, n => n % 2 == 0);

            List<string> students = new List<string> { "Олексій", "Анна", "Богдан", "Андрій" };
            var result = students.FindAll(s => s.StartsWith("А"));
            Console.WriteLine($"Студенти на 'А': {string.Join(", ", result)}");
        }

        public static void FilterArray(int[] numbers, FilterPredicate predicate)
        {
            foreach (var n in numbers)
                if (predicate(n)) Console.Write(n + " ");
            Console.WriteLine();
        }
    }
}