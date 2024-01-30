int peopleCount = int.Parse(Console.ReadLine());
List<Person> people = ReadPeople(peopleCount);



string condition = Console.ReadLine();
int ageThreshold = int.Parse(Console.ReadLine());
string format = Console.ReadLine();

Func<Person, bool> filter = CreateFilter(condition, ageThreshold);
Action<Person> printer = CreatePrinter(format);

static List<Person> ReadPeople(int peopleCount)
{
        List<Person> people = new List<Person>();
    for (int i = 0; i < peopleCount; i++)
    {
        string[] input = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries);
        string name = input[0];
        int age = int.Parse(input[1]);
        Person person = new Person(name,age);
        people.Add(person);
    }
        return people;
}

PrintFilteredPeople(people, filter, printer);
static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
{
    Func<Person, bool> filter = null;
    if (condition == "younger")
    {
        filter = Person => Person.Age < ageThreshold;
    }
    else if (condition == "older")
    {
        filter = Person => Person.Age >= ageThreshold;
    }
    return filter;
}


static Action<Person> CreatePrinter(string format)
{
    Action<Person> printer = null;
    if (format == "age")
    {
        printer = person => Console.WriteLine(person.Age);
    }
    else if (format == "name")
    {
        printer = person => Console.WriteLine(person.Name);
    }
    else if (format == "name age")
    {
        printer = person => Console.WriteLine($"{person.Name} - {person.Age}");
    }
   return printer;
}


static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
{
    foreach (var person in people.Where(filter))
    {
        printer(person);
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
/* second variant
﻿namespace _05._Agefilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int lines = int.Parse(Console.ReadLine());

            Person[] people = new Person[lines];

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people[i] = new Person();
                people[i].Name = input[0];
                people[i].Age = int.Parse(input[1]);
            }


            var temp = people.Select(p => p.Name).ToArray();

            // Read filer data
            string filter = Console.ReadLine(); // store the filter - older/younger
            int filterAge = int.Parse(Console.ReadLine()); // Age
            string format = Console.ReadLine(); // Format of the output

            // Create references to methods
            Func<Person, bool> predicate = GetAgeCondition(filter, filterAge);
            Func<Person, string> formatter = GetFormatter(format);

            PrintPeople(people, predicate, formatter);

            static void PrintPeople(Person[] people, Func<Person, bool> predicate, Func<Person, string> formatter)
            {
                foreach (Person person in people)
                {
                    if (predicate(person))
                    {
                        Console.WriteLine(formatter(person));
                    }
                }
            }

            static Func<Person, bool> GetAgeCondition(string filter, int filterAge)
            {
                if (filter == "younger")
                {
                    return p => p.Age < filterAge; // Predicate to return true if person is younger
                }
                else if (filter == "older")
                {
                    return p => p.Age >= filterAge;
                }
                return null;
            }

            static Func<Person, string> GetFormatter(string format)
            {
                if (format == "name")
                {
                    return p => $"{p.Name}";
                }
                else if (format == "age")
                {
                    return p => $"{p.Age}";
                }
                else if (format == "name age")
                {
                    return p => $"{p.Name} - {p.Age}";
                }

                return null;
            }
        }
    }

    // Declare our own type
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
 */