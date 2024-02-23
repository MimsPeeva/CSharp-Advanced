int[] numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int n = numbers[0];
int m = numbers[1];
HashSet<int> numbersInN = new HashSet<int>();
HashSet<int> numbersInM = new HashSet<int>();

for (int i = 0; i < n; i++)
{
    int number = int.Parse(Console.ReadLine());
    numbersInN.Add(number);
}
for (int i = 0; i < m; i++)
{
    int number = int.Parse(Console.ReadLine());
    numbersInM.Add(number);
}
numbersInN.IntersectWith(numbersInM);
foreach (int number in numbersInN)
{
    Console.Write($"{number} ");
}