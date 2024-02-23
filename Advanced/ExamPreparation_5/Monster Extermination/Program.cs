using Microsoft.VisualBasic;

Queue<int> armorOfMonsters = new(Console.ReadLine()
    .Split(',', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Stack<int> strikingImpact = new(Console.ReadLine()
    .Split(',', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

int killedMonsters = 0;

while (armorOfMonsters.Any() && strikingImpact.Any())
{
    int armour = armorOfMonsters.Peek();
    int strike = strikingImpact.Peek();
    if (armour<=strike)
    {
        killedMonsters++;
        strike -= armour;
        if (strike == 0)
        {

            strikingImpact.Pop();
            armorOfMonsters.Dequeue();
        }
        else
        {
            armorOfMonsters.Dequeue();
            if (strikingImpact.Count == 1)
            {
                strikingImpact.Pop();
                strikingImpact.Push(strike);
                continue;
            }
        }
    }
    else 
    {
      armour -= strike;
        armorOfMonsters.Dequeue();
        armorOfMonsters.Enqueue(armour);
        strikingImpact.Pop();
    }
}
if (armorOfMonsters.Count == 0)
{ Console.WriteLine("All monsters have been killed!"); }
if(strikingImpact.Count==0)
{ Console.WriteLine("The soldier has been defeated."); }
Console.WriteLine($"Total monsters killed: {killedMonsters}");