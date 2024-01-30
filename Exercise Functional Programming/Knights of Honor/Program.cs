string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
Action<string> printer = names=>Console.WriteLine($"Sir {names}");
foreach (string name in names)
{
    printer(name);
}