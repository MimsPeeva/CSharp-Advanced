Queue<int> textiles = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Stack<int> medicaments = new(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
int medKit = 0;
int bandage = 0;
int patch = 0;
while (textiles.Any()|| medicaments.Any())
{
    if (textiles.Count == 0)
    { break; }
    else if (medicaments.Count == 0)
    { break; }
    int sum = textiles.Peek() + medicaments.Peek();
    switch (sum)
    {
        case 100:medKit++;textiles.Dequeue();medicaments.Pop(); break;
        case 40: bandage++; textiles.Dequeue(); medicaments.Pop(); break;
        case 30: patch++; textiles.Dequeue(); medicaments.Pop(); break;
        case > 100: medKit++; textiles.Dequeue(); medicaments.Pop(); medicaments.Push(medicaments.Pop()+(sum-100)); break;
        default: textiles.Dequeue(); medicaments.Push(medicaments.Pop() +10);break;
    }
}
 if(medicaments.Count==0&&textiles.Count==0)
{ Console.WriteLine("Textiles and medicaments are both empty."); }
else if (textiles.Count==0)
{
    Console.WriteLine("Textiles are empty.");
}
else if (medicaments.Count==0)
{
    Console.WriteLine("Medicaments are empty.");
}
if (medKit > 0)
{
    Console.WriteLine($"MedKit - {medKit}");
}
if (bandage > 0)
{
    Console.WriteLine($"Bandage - {bandage}");
}
if (patch > 0)
{
    Console.WriteLine($"Patch - {patch}");
}

if (textiles.Any())
{
    Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
}
if (medicaments.Any())
{
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
 
}
