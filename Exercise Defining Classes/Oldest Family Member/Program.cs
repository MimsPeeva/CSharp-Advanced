namespace DefiningClasses;
public class StartUp
{
    public static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        Family list = new();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = input[0];
            int age = int.Parse(input[1]);
            Person person = new();
            person.Name = name;
            person.Age = age;
            list.AddMember(person);
        }
      Person oldestPerson = list.GetOldestMember();
        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }
}
/*
3
Peter 3
George 4
Annie 5
 */