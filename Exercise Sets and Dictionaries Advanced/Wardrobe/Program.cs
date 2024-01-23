int clothesN = int.Parse(Console.ReadLine());
Dictionary<string,Dictionary<string,int>> wardrobe= new();
for (int i = 0; i < clothesN; i++)
{
    string[] input = Console.ReadLine()
        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
    string color = input[0];
    string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
    if (!wardrobe.ContainsKey(color))
    {
        wardrobe.Add(color, new Dictionary<string, int>());
    }
    foreach (string item in clothes)
    {
        if (!wardrobe[color].ContainsKey(item))
        { wardrobe[color].Add(item, 1); }
        else { wardrobe[color][item]++; }
    }
}
string[] itemToFind = Console.ReadLine()
        .Split();
string colorToFind = itemToFind[0];
string clToFind = itemToFind[1];
foreach (var color in wardrobe)
{
    Console.WriteLine($"{color.Key} clothes:");
    foreach (var item in color.Value)
    {

            Console.Write($"* {item.Key} - {item.Value}");
        if (color.Key == colorToFind && item.Key == clToFind)
        {
            Console.Write($" (found!)");
        }
        Console.WriteLine();
    }
}
/*
4
Blue -> dress,jeans,hat
Gold -> dress,t-shirt,boxers
White -> briefs,tanktop
Blue -> gloves
Blue dress
 */