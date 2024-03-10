﻿namespace SumOfIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
               .Split(" ");
            int sum = 0;
            foreach (var element in input)
            {
                try
                {
                    sum += int.Parse(element);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }

}
//9876 string 10 -2147483649 -8 3 4.86555 8
