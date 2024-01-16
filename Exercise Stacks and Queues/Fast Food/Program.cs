int quantityOfTheFood = int.Parse(Console.ReadLine());
int[] orderQuantity = Console.ReadLine().
    Split(' ').
    Select(int.Parse).
    ToArray();
Queue<int> orders = new Queue<int>(orderQuantity);
if (orders.Any())
{ Console.WriteLine(orders.Max()); }
while (orders.Any())
{
    if (quantityOfTheFood >= orders.Peek())
    {
        quantityOfTheFood -= orders.Dequeue();
    }
    else
    {
        Console.WriteLine("Orders left: " + string.Join(' ', orders));
        return;
    }
}
    Console.WriteLine("Orders complete");
  

/*
348
20 54 30 16 7 9
*/