List<double> list = Console.ReadLine()
    .Split()
    .Select(double.Parse)
    .ToList();
Dictionary<double, int> times = new Dictionary<double, int>();
foreach (var item in list)
{
    if (!times.ContainsKey(item))
    { times[item] = 0; }
    times[item]++;
}
foreach (var item in times)
{
    Console.WriteLine($"{item.Key} - {item.Value} times");
}