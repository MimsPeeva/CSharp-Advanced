Func<double, double> VAT = x => x * 0.2;
double[] prices = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .ToArray();
for (int i = 0; i < prices.Length; i++)
{
    prices[i] += VAT(prices[i]);
    Console.WriteLine($"{prices[i]:f2}");
}
/* seccond variant
double[] prices = Console.ReadLine()
 .Split(new string[] { ", " },
 StringSplitOptions.RemoveEmptyEntries)
 .Select(double.Parse)
 .Select(n => n * 1.2)
 .ToArray();
foreach (var price in prices)
 Console.WriteLine($"{price:f2}");
 */