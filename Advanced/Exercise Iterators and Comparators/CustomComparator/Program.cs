﻿
int[] array = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
Array.Sort(array, new MyCustomComparator());
Console.WriteLine(String.Join(" ", array));
public class MyCustomComparator : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (x % 2 == 0 && y % 2 != 0)
        {
            return -1;
        }
        if (x % 2 != 0 && y % 2 == 0)
        {
            return 1;
        }
        return x.CompareTo(y);
    }
}