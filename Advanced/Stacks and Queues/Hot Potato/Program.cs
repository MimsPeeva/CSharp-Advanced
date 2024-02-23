
Queue<string> kidsNames = new Queue<string>(Console.ReadLine().Split());
int n = int.Parse(Console.ReadLine());
int tosses = 1;
while (kidsNames.Count != 1)
{
    for (int i = 0; i < n; i++)
    {
        string childWithPotato = kidsNames.Dequeue();
        if (tosses == n)
        {
            Console.WriteLine($"Removed {childWithPotato}");
            tosses = 0;
        }
        else { kidsNames.Enqueue(childWithPotato); }
        tosses++;
    }
}
Console.WriteLine($"Last is {kidsNames.Dequeue()}");