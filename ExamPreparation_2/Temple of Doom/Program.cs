Queue<int> tools = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
Stack<int> substances = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
List<int> challenges = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();
while (true)
{
    int currtools = tools.Peek();
    int currSubstance = substances.Peek();
int result = currSubstance * currtools;
if (challenges.Contains(result))
{
    challenges.Remove(result);
    tools.Dequeue();
    substances.Pop();
    if (challenges.Count == 0)
    {
        Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
        break;
    }
}
else
{
    tools.Enqueue(tools.Dequeue()+1);
    substances.Push(substances.Pop()-1);
    if (currSubstance == 0)
    {
        substances.Pop();
    }
    if (substances.Count == 0)
    {
    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
    break;
    }
}
}
if (tools.Count != 0)
{
    Console.WriteLine($"toolss: {string.Join(", ", tools)}");
}
if (substances.Count != 0)
{
    Console.WriteLine($"Substances: {string.Join(", ", substances)}");
}
if (challenges.Count != 0)
{
    Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
}