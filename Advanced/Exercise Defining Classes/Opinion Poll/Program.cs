namespace DefiningClasses;
public class StartUp
{
    public static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        List<Person> list = new();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = input[0];
            int age = int.Parse(input[1]);
         //Person person = new Person(name,age);
         //   list.Add(person);
         //second variant
            list.Add(new Person(name,age));
        }
      var result = list.Where(p=>p.Age>30).OrderBy(p=>p.Name);
        foreach (Person person in result)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}