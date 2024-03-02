using System.Reflection;
using System;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
          List<IBirthdatable>list= new();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0]=="Pet")

                {                    
                        Models.Pet pet = new Pet(tokens[1], DateOnly.ParseExact(tokens[2], "dd/MM/yyyy"));
                    list.Add(pet);
                }
                else if (tokens[0]=="Citizen")
                {
                    Models.Citizen citizen = new(tokens[1], int.Parse(tokens[2]), tokens[3], DateOnly.ParseExact(tokens[4], "dd/MM/yyyy"));
                    list.Add(citizen);
                }
            }
            


            DateOnly year = DateOnly.ParseExact(Console.ReadLine(), "yyyy");

                foreach (var birthable in list)
                {
                    if (birthable.BirthDate.Year == year.Year)
                    {
                        Console.WriteLine(birthable.BirthDate.ToString($"dd/MM/yyyy"));
                    }
                }
           
        }
    }
}
/*
Citizen Peter 22 9010101122 10/10/1990
Pet Sharo 13/11/2005
Robot MK-13 558833251
End
1990


Robot VV-XYZ 11213141
Citizen Corso 35 7903210713 21/03/1979
Citizen Kane 40 7409073566 07/09/1974
End
1975
 

Citizen Stam 16 0041018380 01/01/2000
Robot MK-10 12345678
Robot PP-09 00000001
Pet Topcho 24/12/2000
Pet Rex 12/06/2002
End
2000
 */