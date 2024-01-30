using System.Security.Cryptography.X509Certificates;

int[] numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int divisor = int.Parse(Console.ReadLine());
Predicate<int> predicate = number => number%divisor!=0;
var result = numbers.Where(number => predicate(number)).Reverse().ToArray();
Action<int[]> print = numbers => Console.WriteLine(string.Join(" ",numbers));
print(result);