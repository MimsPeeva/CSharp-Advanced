using GenericCountMethodString;
using System.Security.Cryptography.X509Certificates;

public class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Box<string> box = new Box<string>();
        for (int i = 0; i < n; i++)
        {
            box.AddItem(Console.ReadLine());
        }
        string value = Console.ReadLine();
    Console.WriteLine(box.Count(value));
    }
}