
int[] range = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
string command = Console.ReadLine();
int startN = range[0];
int stopN = range[1];
        List<int> numbers = new List<int>();
    for (int i = startN ; i <= stopN; i++)
    {
    numbers.Add(i);
    }
Predicate<int> predicate = i => true;
    if (command == "even")
    {
               predicate =i => i% 2 == 0;
    }
    else if (command == "odd")
            {
    predicate = i => i % 2 != 0;

}
var filteredNumbers = numbers
.Where(new Func<int, bool>(predicate));
Console.WriteLine(string.Join(' ', filteredNumbers));