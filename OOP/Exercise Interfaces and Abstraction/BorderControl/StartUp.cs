using BorderControl.Models;
using System.Reflection.Metadata;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Models.BorderControl borderControl = new ();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 2)
                {
                    Robot robot = new Robot(tokens[0], tokens[1]);
                    borderControl.AddEntityForBorderControl(robot);
                }
                else if(tokens.Length==3)
                {
                    Citizen citizen = new(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    borderControl.AddEntityForBorderControl(citizen);

                }
            }
            string n = Console.ReadLine();
            var detained = borderControl.EntitiesToCheck.Where(e=>e.Id.EndsWith(n));

            foreach (var baseEntity in detained)
            {
                Console.WriteLine(baseEntity.Id);
            }
        }
    }
}
/*
Peter 22 9010101122
MK-13 558833251
MK-12 33283122
End
122
*/