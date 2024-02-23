string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
Action<string> print = names=>Console.WriteLine(names);
foreach (string name in names)
{
    print(name);
}