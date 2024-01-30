int n = int.Parse(Console.ReadLine());
string[] names = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
Func<string, bool> function = name => name.Length <= n;
Action<string> print = name => Console.WriteLine(name);
foreach (string name in names)
{
    if (function(name))
    {
        print(name);
    }
}
/*
4
Karl Anna Kris Yahto
*/