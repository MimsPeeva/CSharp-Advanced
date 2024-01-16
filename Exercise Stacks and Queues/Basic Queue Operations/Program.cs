int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
Queue<int> numbers = new Queue<int>();
int n = input[0];
int s = input[1];
int x = input[2];
string[] numbersToAdd = Console.ReadLine().Split();
foreach (var item in numbersToAdd)
{
    int currentNumber = int.Parse(item);
    numbers.Enqueue(currentNumber);
}

for (int i = 0; i < s; i++)
{
    numbers.Dequeue();
}
if (numbers.Contains(x))
{
    Console.WriteLine("true");
}
else if (numbers.Any())
{
    Console.WriteLine(numbers.Min());
}
else { Console.WriteLine("0"); }
/*
5 2 13
1 13 45 32 4
 */