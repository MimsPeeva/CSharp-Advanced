List<int> numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .OrderByDescending(n=>n)
    .Take(3)
    .ToList();

Console.WriteLine(string.Join(" ", numbers));