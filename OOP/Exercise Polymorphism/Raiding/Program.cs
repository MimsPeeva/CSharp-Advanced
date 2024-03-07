using Raiding.Models;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> list = new();
            int n = int.Parse(Console.ReadLine());
            while (list.Count < n)
            {
            
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                if (type == "Druid")
                {
                    list.Add(new Druid(name));
                }
                else if (type == "Paladin")
                {
                    list.Add(new Paladin(name));
                }
                else if (type == "Rogue")
                {
                    list.Add(new Rogue(name));
                }
                else if (type == "Warrior")
                {
                    list.Add(new Warrior(name));
                }
                else { Console.WriteLine("Invalid hero!"); }
            
                
            }
            int result = list.Sum(hero=>hero.Power);
            int bossPower = int.Parse(Console.ReadLine());
            foreach (var hero in list)
            {
                Console.WriteLine(hero.CastAbility());
               
            }
            Console.WriteLine(result>=bossPower?"Victory!":"Defeat...");
        }
    }
}
/*
3
Mike
Paladin
Josh
Druid
Scott
Warrior
250

2
Mike
Warrior
Tom
Rogue
200
 */