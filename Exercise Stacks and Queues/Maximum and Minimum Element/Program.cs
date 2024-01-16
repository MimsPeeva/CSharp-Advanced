Stack<int> numbers = new Stack<int>();
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    int[] input = Console.ReadLine().
        Split().
        Select(int.Parse).
        ToArray();
    int command = input[0];
    if (command == 1)
    {
        numbers.Push(input[1]);
    }
    else if (command == 2)
    { numbers.Pop(); }
    else if (command == 3)
    {
        if (numbers.Any())
        { 
            Console.WriteLine(numbers.Max()); 
        } 
    }
    else if (command == 4)
    {
        if (numbers.Any())
        {
            Console.WriteLine(numbers.Min()); 
        }
    }
}
Console.WriteLine(string.Join(", ",numbers));