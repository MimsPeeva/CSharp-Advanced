List<string> commingPeople = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .ToList();
string lines = string.Empty;
List<string> removedAfterFiltering = new List<string>();
while ((lines = Console.ReadLine()) != "Print")
{
    string[] tokens = lines.Split(";", StringSplitOptions.RemoveEmptyEntries);
    string command = tokens[0];
    string filterType = tokens[1];
    string filterParameter = tokens[2];
  

    Predicate<string> filter = GetPredicate(filterType, filterParameter);

    switch (command)
    {
        case "Add filter":
            removedAfterFiltering.AddRange(commingPeople.Where(x => filter(x)));
            commingPeople.RemoveAll(filter);
            break;
        case "Remove filter":
            commingPeople.AddRange(commingPeople.Where(x => filter(x)));
            break;
    }
}
Console.WriteLine(string.Join(' ', commingPeople));


static Predicate<string> GetPredicate(string filterType, string filterParameter)
{
    switch (filterType)
    {
        case "Starts with":
            return g => g.StartsWith(filterParameter);
        case "Ends with":
            return g => g.EndsWith(filterParameter);
        case "Length":
            return g => g.Length == int.Parse(filterParameter);
        case "Contains":
            return g => g.Contains(filterParameter);
    }

    return x => true;

}
/*
Peter Misha Slav
Add filter;Starts with;P
Add filter;Starts with;M
Print
 */