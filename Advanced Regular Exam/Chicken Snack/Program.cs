Stack<int> money = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Queue<int> foodPrices = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

int foodCount = 0;

while (money.Any()&&foodPrices.Any())
{
    int currMoney = money.Peek();
    int currPrice = foodPrices.Peek();
    if (currMoney == currPrice)
    {
        foodCount++;
        money.Pop();
        foodPrices.Dequeue();
    }
    if (currMoney > currPrice)
    {
        int diff = currMoney - currPrice;
        foodCount++;
        money.Push(money.Pop()+diff);
        foodPrices.Dequeue();
    }
    if (currMoney < currPrice)
    {
        money.Pop();
        foodPrices.Dequeue();
    }
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
