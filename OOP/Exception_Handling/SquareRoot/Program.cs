using System.Runtime.CompilerServices;

namespace SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(SquareRoot(n));   
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally { Console.WriteLine("Goodbye."); }

            
        }
        private static double SquareRoot(int n)
        {
            if (n < 0)
            { throw new ArgumentException("Invalid number."); }
             return Math.Sqrt(n);
        }
    }
}