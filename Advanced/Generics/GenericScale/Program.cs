namespace GenericScale
{
    public class Program
    {
        static void Main(string[] args)
        {
            EqualityScale<int> scale = new EqualityScale<int>(8,8);
            Console.WriteLine(scale.AreEqual());
        }
    }
}