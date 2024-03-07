using System;
using System.Collections.Generic;
using System.Linq;
using System;
using WildFarm.Models;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string[] input)
        {
            switch(input[0])
            {
                case "Owl":return new Owl(input[1],double.Parse(input[2]),double.Parse(input[3])); break;
                case "Hen":return new Hen(input[1], double.Parse(input[2]), double.Parse(input[3])); break;
                case "Mouse":return new Mouse(input[1], double.Parse(input[2]), input[3]); break;
                case "Dog":return new Dog(input[1], double.Parse(input[2]), input[3]); break;
                case "Cat":return new Cat(input[1], double.Parse(input[2]), input[3], input[4]); break;
                case "Tiger":return new Tiger(input[1], double.Parse(input[2]), input[3], input[4]); break;
                default:
                    throw new ArgumentException("Invalid type animal");
                    break;

            }

        }
    }
}
