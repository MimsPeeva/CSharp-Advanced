﻿int n = int.Parse(Console.ReadLine());
SortedSet<string> elements = new SortedSet<string>();
for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split();
    for (int j = 0; j < input.Length; j++)
    {
        elements.Add(input[j]);
    }
}
foreach (string el in elements)
{
    Console.Write($"{el} ");
}
/*
4
Ce O
Mo O Ce
Ee
Mo
*/