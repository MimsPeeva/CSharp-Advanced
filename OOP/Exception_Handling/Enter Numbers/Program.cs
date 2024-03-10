public class Program
{
    static void Main()
    {
        Stack<int> list = new();
        int start = 1;
        while(list.Count <10)
        {
            try
            {list.Push(ReadNumber(start, 100)); }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number!");
            }
            catch (ArgumentException ex) 
            { Console.WriteLine(ex.Message); }
            if (list.Count > 0)
            {
                start = list.Peek();
            }
        }
        Console.WriteLine(string.Join(", ", list.Reverse().ToList()));
    }
    private static int ReadNumber(int start , int end)
    {
        int n = int.Parse(Console.ReadLine());
        if (n <= start || n >= end)
        { throw new ArgumentException($"Your number is not in range {start} - 100!"); }
        
        return n;
    }
}