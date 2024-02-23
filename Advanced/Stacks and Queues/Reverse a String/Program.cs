namespace Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chars = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>(chars);
            while (stack.Count != 0)
            { Console.Write(stack.Pop()); }
        }
    }
}