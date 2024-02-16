Stack<int> worms = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Queue<int> holes = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

int wormsCount = worms.Count;
int matchesCount = 0;

while (worms.Any() && holes.Any())
{
    if (worms.Peek() == holes.Peek())
    {
        matchesCount++;
        worms.Pop();
        holes.Dequeue();
        continue;
    }
   
        holes.Dequeue();
        worms.Push(worms.Pop() - 3);
    
    if (worms.Peek() < 1)
    {
        worms.Pop();
    }
}
if (matchesCount > 0)
{
    Console.WriteLine($"Matches: {matchesCount}");
}
else { Console.WriteLine("There are no matches."); }


Worms(worms, wormsCount, matchesCount);

Holes(holes);

static void Worms(Stack<int> worms, int wormsCount, int matchesCount)
{
    if (matchesCount == wormsCount && !worms.Any())
    {
        Console.WriteLine("Every worm found a suitable hole!");
    }
    else if (matchesCount < wormsCount && !worms.Any())
    {
        Console.WriteLine("Worms left: none");
    }
    if (worms.Any())
    { Console.WriteLine($"Worms left: {string.Join(", ", worms)} "); }
}

static void Holes(Queue<int> holes)
{
    if (!holes.Any())
    { Console.WriteLine("Holes left: none"); }
    else
    {
        Console.WriteLine($"Holes left: {string.Join(", ", holes)} ");
    }
}