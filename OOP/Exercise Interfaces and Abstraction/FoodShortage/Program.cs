using FoodShortage.Models;
using FoodShortage.Models.Interfaces;
using System;
using System.Xml.Linq;

namespace FoodShortage
{
 
        public class StartUp
        {
            static void Main(string[] args)
            {
            List<IBuyer> list = new();

            //List<Citizen> citizenList = new List<Citizen>();
            //List<Rebel> rebelList = new List<Rebel>();


            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 4)
                { list.Add(new Citizen(input[0], int.Parse(input[1]), input[2], input[3])); }
                else
                { list.Add(new Rebel(input[0], int.Parse(input[1]), input[2])); }
            }
            string name;
            while ((name = Console.ReadLine())!="End")
            {
               
                IBuyer curr = list.FirstOrDefault(b => b.Name == name);
              curr?.BuyFood();
            }
           
          
            Console.WriteLine(list.Sum(b => b.Food));
        }
        
    }
    }

/*
2
Peter 25 8904041303 04/04/1989
Stan 27 WildMonkeys
Peter
George
Peter
End

4
Stam 23 TheSwarm
Ton 44 7308185527 18/08/1973
George 31 Terrorists
Pen 27 881222212 22/12/1988
John
Geo rge
John
Joro
Stam
Pen
End
 */