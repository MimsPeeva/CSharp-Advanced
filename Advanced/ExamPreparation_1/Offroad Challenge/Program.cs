Stack<int> fuel = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Queue<int> consumptionIndexes = new(Console.ReadLine()
   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
   .Select(int.Parse));

Queue<int> quantities = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

int altitude = 1;
bool didNotReach = false;

while (fuel.Count>0)
{
    int currFuel = fuel.Pop();
    int currIndex = consumptionIndexes.Dequeue();
    int currQuantity = quantities.Dequeue();
    
    if ((currFuel - currIndex) >= currQuantity)
    {
        Console.WriteLine($"John has reached: Altitude {altitude++}");
    }
    else 
    {
        Console.WriteLine($"John did not reach: Altitude {altitude--}");
        didNotReach = true;
        break;
    }
}

if (didNotReach)
{
    Console.WriteLine("John failed to reach the top.");
    if (altitude == 0)
    {
        Console.WriteLine("John didn't reach any altitude.");
    }
    else
    {
        Console.Write("Reached altitudes: ");
        for (int i = 0; i < altitude; i++)
        {
            Console.Write($"Altitude {i + 1}");
            if (i < altitude - 1)
            { Console.Write(", "); }
        }
    }
}
else
{
    Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
}
/*
40 66 123 100
10 30 70 33
40 55 77 100
*/