Stack<int> money = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Queue<int> foodPrices = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

int foodCount = 0;
int diff = 0;
while (money.Any() && foodPrices.Any())
{
    int currMoney = money.Pop();
    int currPrice = foodPrices.Dequeue();
    currMoney += diff;
    if (currMoney == currPrice)
    {
        foodCount++;
    }
    if (currMoney > currPrice)
    {
        diff = currMoney - currPrice;
        foodCount++;
    }
    if (!money.Any()) { break; }
    if (!foodPrices.Any()) { break; }
}
if (foodCount >= 4)
{
    Console.WriteLine($"Gluttony of the day! Henry ate {foodCount} foods.");
}
else if (foodCount > 1)
{ Console.WriteLine($"Henry ate: {foodCount} foods."); }
else if (foodCount == 1)
{ Console.WriteLine($"Henry ate: {foodCount} food."); }
else Console.WriteLine($"Henry remained hungry. He will try next weekend again.");


