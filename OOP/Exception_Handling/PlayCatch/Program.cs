using System.Text;

namespace PlayCatch
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
              .Split(" ")
              .Select(int.Parse)
              .ToArray();

                int exceptions = 0;
            while (true)
            {
                if (exceptions == 3)
                {
                   break;
                }
                    string[] tokens = Console.ReadLine()
                        .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                    string command = tokens[0];
                try
                {
                    int firstIndex = int.Parse(tokens[1]);
                    if (command == "Replace")
                    {
                        int el = int.Parse(tokens[2]);
                        arr[firstIndex] = el;
                    }
                    else if (command == "Print")
                    {
                        StringBuilder sb = new();
                        int secondIndex = int.Parse(tokens[2]);
                        for (int i = firstIndex; i <= secondIndex; i++)
                        {
                           
                            if (i == secondIndex)
                            {
                                sb.Append(arr[i]);
                            }
                            else
                            {
                                sb.Append(arr[i] + ", ");
                            }
                        }
                        Console.WriteLine(sb.ToString().TrimEnd());
                    }
                    else if (command == "Show")
                    {
                        Console.WriteLine(arr[firstIndex]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptions++;
                }   
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptions++;
                }
            }
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
/*
1 2 3 4 5
Replace 1 9
Replace 6 3
Show 3
Show peter
Show 6

1 2 3 4 5
Replace 3 9
Print 1 4
Print -3 12
Print 1 5
Show 3
Show 12.3
 */