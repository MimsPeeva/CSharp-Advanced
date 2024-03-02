using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping
    {
        private const double BaseCalories = 2.0;
        private const double MeatModifier = 1.2;
        private const double VeggiesModifier = 0.8;
        private const double CheeseModifier = 1.1;
        private const double SauceModifier = 0.9;
        private readonly string topingType;
        private double weight;
        public Topping(string topingType, double weight)
        {
            TopingType = topingType;
            Weight = weight;
        }
        public double Weight 
        {
            get => weight;
            set
            { if (value is < 1 or > 50)
                    throw new ArgumentException($"{topingType} weight should be in the range [1..50].");
                weight = value;
                        }
        }
        public string TopingType
        {
            get=> topingType;
            init 
            {
                if (value.ToLower() is not ("meat"or"veggies"or"cheese" or"sauce"))
                { throw new ArgumentException($"Cannot place {value} on top of your pizza."); }
                topingType = value;
            }
        }
        //public double CaloriesPerGram()
        //{
        //    return TopingType.ToLower() switch
        //    {
        //        "meat" => BaseCalories * 1.2,
        //        "vegies" => BaseCalories * 0.8,
        //        "cheese" => BaseCalories * 1.1,
        //        "sauce" => BaseCalories * 0.9
        //    };

        //}

        public double CaloriesPerGram()
        {
            double calories =  BaseCalories;

            if (TopingType.ToLower() == "meat")
            {
                calories *= MeatModifier;
            }
            else if (TopingType.ToLower() == "veggies")
            {
                calories *= VeggiesModifier;
            }
            else if (TopingType.ToLower() == "cheese")
            {
                calories *= CheeseModifier;
            }
            else
            {
                calories *= SauceModifier;
            }

            return calories;
        }
    }
}
