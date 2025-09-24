using System;
namespace Task5;
public class Program
{
    public static double GetAverage(int[] marks)
    {
        int sum = 0;
        foreach (int m in marks)
            sum += m;
        return (double)sum / marks.Length;
    }

    public static int GetMin(int[] marks)
    {
        int min = marks[0];
        foreach (int m in marks)
            if (m < min) min = m;
        return min;
    }

    public static int GetMax(int[] marks)
    {
        int max = marks[0];
        foreach (int m in marks)
            if (m > max) max = m;
        return max;
    }

    public static void PrintGroupStatistics(int[][] groups)
    {
        for (int i = 0; i < groups.Length; i++)
        {
            double avg = GetAverage(groups[i]);
            int min = GetMin(groups[i]);
            int max = GetMax(groups[i]);

            Console.WriteLine($"Група {i + 1}: Середній = {avg:F0}, Мінімальний = {min}, Максимальний = {max}");
        }
    }

    public static void Main(string[] args)
    {
        int[][] groups =
        {
            new int[] { 80, 90, 70, 100, 60 },
            new int[] { 50, 65, 70, 80, 95 },
            new int[] { 90, 92, 100, 98, 95 }
        };

        PrintGroupStatistics(groups);
    }
}
    