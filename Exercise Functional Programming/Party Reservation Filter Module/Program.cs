List<string> commingPeople = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .ToList();
string lines = string.Empty;
while ((lines = Console.ReadLine()) != "Print")
{
    string[] tokens = lines.Split(";", StringSplitOptions.RemoveEmptyEntries);
    string command = tokens[0];
    string filterType = tokens[1];
    string filterParameter = tokens[2];
    Func<string, bool> predicate = GetPredicate(filterType,filterParameter);
    if (command == "Add filter")
    {
        commingPeople = AddFilter(commingPeople,predicate);
    }
    else if (command == "Remove filter")
    {
        commingPeople = RemoveFilter(commingPeople, predicate);

    }
}
Console.WriteLine(commingPeople.Any() ?
    $"{string.Join(", ", commingPeople)}" :
    "");


List<string> RemoveFilter(List<string> guestList, Func<string, bool> predicate)
{
    List<string> result = new List<string>();
    foreach (string guest in guestList)
    {
        if (result.Contains(guest))
        {
            result.Remove(guest);
        }
    }
    return result;
}

List<string> AddFilter(List<string> guestList, Func<string, bool> predicate)
{
    List<string> result = new List<string>();
    foreach (string guest in guestList)
    {
        if (!predicate(guest))
        {
            result.Add(guest);
        }
    }
    return result;
}

Func<string, bool> GetPredicate(string filterType, string filterParameter)
{
    if (filterType == "Starts with")
    {
        return n => n.StartsWith(filterParameter);
    }
    if (filterType == "Ends with")
    {
        return n => n.EndsWith(filterParameter);

    }
    if (filterType == "Length")
    {
        return n => n.Length==int.Parse(filterParameter);
    }
    if (filterType == "Contains")
    {
        return n => n.Contains(filterParameter);

    }
    return default;

}
/*
Peter Misha Slav
Add filter;Starts with;P
Add filter;Starts with;M
Print
 */