int end = int.Parse(Console.ReadLine());
int[] dividers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
List<int> numbers = new List<int>();

    for (int i = 1; i <= end; i++)
    {
            numbers.Add(i);
    }
Func<int[], int, bool> function = (arr, i)=>
    {
    bool isDivisible = true;
        foreach (int n in dividers)
        {
            if (i % n != 0)
            { isDivisible = false; }
        }
return isDivisible;
    };
var result = numbers.Where(n=> function(dividers,n)).ToArray();
Console.WriteLine(string.Join(" ",result));