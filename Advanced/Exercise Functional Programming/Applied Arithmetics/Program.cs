int[] numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Func<int, int> function = x => x;
Action<int[]> print = numbers => Console.WriteLine(string.Join(" ", numbers));
string command = string.Empty;
while ((command=Console.ReadLine())!="end")
{
    if (command == "add")
    {
        foreach (int n in numbers)
        {
           function = n => n + 1;
        }
    }
    else if (command == "multiply")
    {
        foreach (int n in numbers)
        {
            function = n => n * 2;
        }
    }
    else if (command == "subtract")
    {
        foreach (int n in numbers)
        {
            function = n => n - 1;
        }
    }
    else if (command == "print")
    {  
            print(numbers);
    continue;
    }
numbers = numbers.Select(x=> function(x)).ToArray();
}