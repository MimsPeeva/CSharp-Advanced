string input = string.Empty;
Dictionary<string, Dictionary<string,double>> shops = new Dictionary<string, Dictionary<string, double>>();
while ((input = Console.ReadLine()) != "Revision")
{
    string[] tokens = input.Split(", ");
    string shop = tokens[0];
    string product = tokens[1];
    double price = double.Parse(tokens[2]);
    if (!shops.ContainsKey(shop))
    { shops.Add(shop,new Dictionary<string, double>()); }
    if (!shops[shop].ContainsKey(product))
    {
        shops[shop].Add(product,0); 
    }
    shops[shop][product] = price;
}

shops = shops.OrderBy(n => n.Key).ToDictionary(n=>n.Key, n=>n.Value);
foreach (var(shop, products) in shops)
{
    Console.WriteLine($"{shop}->");
    foreach (var (product, price) in products)
    {
        Console.WriteLine($"Product: {product}, Price: {price}");
    }
}