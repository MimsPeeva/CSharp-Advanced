List<string> commingPeople = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .ToList();
string lines = string.Empty;

while ((lines = Console.ReadLine())!= "Party!")
{
    string[] tokens = lines.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = tokens[0];
    string filterType = tokens[1];
    string filterParameter = tokens[2];
    Func<string, bool> predicate = GetPredicate(tokens[1], tokens[2]);
    if (command == "Remove")
    {
        commingPeople = Remove(commingPeople,predicate);
    }
    else if (command == "Double")
    {
        commingPeople = Double(commingPeople, predicate);
    }
}
Console.WriteLine(commingPeople.Any() ?
    $"{string.Join(", ", commingPeople)} are going to the party!" :
    "Nobody is going to the party!");

static Func<string, bool> GetPredicate(string command, string criteria)
{
    if (command == "StartsWith")
    {
        return s => s.StartsWith(criteria);
    }
     if (command == "EndsWith")
    {
        return s => s.EndsWith(criteria);
    }
     if (command == "Length")
    {
        return s => s.Length == int.Parse(criteria);
    }
    return default;
}


static List<string> Double(List<string> guestList, Func<string,bool>predicate)
{
    List<string> result = new List<string>();
    foreach (string guest in guestList)
    {
        if (predicate(guest))
        {
            result.Add(guest);
        }
        result.Add(guest);
    }
    return result;
}
static List<string> Remove(List<string> guestList, Func<string, bool> predicate)
{
    guestList = guestList.Where(guest=>predicate(guest)==false).ToList();
    return guestList;
}

