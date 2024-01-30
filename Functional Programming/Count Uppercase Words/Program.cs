Func<string, bool> isUpper = t => char.IsUpper(t[0]);
string[] text = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(isUpper)
    .ToArray();
Console.WriteLine(string.Join("\n", text));