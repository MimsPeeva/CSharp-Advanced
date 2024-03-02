using FoodShortage.Models;
using FoodShortage.Models.Interfaces;
using System;
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
                { list.Add(new Citizen(input[0], int.Parse(input[1]), input[2], DateOnly.Parse(input[3]))); }
                else
                { list.Add(new Rebel(input[0], int.Parse(input[1]), input[2])); }
            }
            List<string> names = new();
            string command;
            while ((command=Console.ReadLine())!="End")
            {
                names.Add(Console.ReadLine());
            }

            foreach (var name in names)
            {
                if (list.FirstOrDefault(b => b.Name == name) != default)
                {
                    IBuyer currentBuyer = list.FirstOrDefault(b => b.Name == name);
                    currentBuyer.BuyFood();
                }
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
 */