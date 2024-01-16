int[] clothes = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int capacity = int.Parse(Console.ReadLine());
Stack<int> stack = new Stack<int>(clothes);
int racks = 0;
int currentRackCapacity = capacity;
if (stack.Any())
{ racks++ ; }
while (stack.Any())
{
    if (stack.Peek() <= currentRackCapacity)
    {
        currentRackCapacity -= stack.Pop();
    }
else 
    { racks++; currentRackCapacity = capacity; }

}
Console.WriteLine(racks);
/*
5 4 8 6 3 8 7 7 9
16
 */