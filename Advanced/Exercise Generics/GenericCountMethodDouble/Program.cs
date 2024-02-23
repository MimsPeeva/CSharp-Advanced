namespace GenericCountMethodDouble;
public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Box<double> box = new Box<double>();
        for (int i = 0; i < n; i++)
        {
            box.AddItem(double.Parse(Console.ReadLine()));
        }
        double value = double.Parse(Console.ReadLine());
        Console.WriteLine(box.Count(value).ToString());
    }
}