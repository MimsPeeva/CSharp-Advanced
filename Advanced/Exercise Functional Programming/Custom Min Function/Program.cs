int[] integers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
if (!integers.Any())
{
    return;
}
Func<int[], int> minN = (int[]numbers) => 
    {
    int min = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
return min;
    };
Console.WriteLine(minN(integers));