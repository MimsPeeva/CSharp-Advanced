using ComparingObjects;

string input = string.Empty;
List<Person> peopleList = new();
while ((input = Console.ReadLine()) != "END")
{
    string[] lines = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    Person person = new()
    {
        Name = lines[0],
        Age = int.Parse(lines[1]),
        Town = lines[2]
    };

    peopleList.Add(person);
}
int n = int.Parse(Console.ReadLine())-1;
Person referencePerson = peopleList[n];
int equalCount=0;
int diffCount = 0;
foreach (var person in peopleList)
{
    if (person.CompareTo(referencePerson) == 0)
    {
        equalCount++;
    }
    else diffCount++;
}
if (equalCount == 1)
{
    Console.WriteLine("No matches");
}
else Console.WriteLine($"{equalCount} {diffCount} {peopleList.Count}");
/*
Peter 22 Varna
George 14 Sofia
END
2

Peter 22 Varna
George 22 Varna
George 22 Varna
END
2
 */