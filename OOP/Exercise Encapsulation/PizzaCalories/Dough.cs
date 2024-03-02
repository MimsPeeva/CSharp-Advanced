using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {
        private readonly string flourType;
        private readonly string bakingTechnique;
        private const double BaseCalories = 2.0;
        private readonly double weight;
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => flourType;
            init
            { if (value.ToLower() is not ("white" or "wholegrain"))
                { throw new ArgumentException("Invalid type of dough."); }
                flourType = value; 
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            init 
            {
                if (value.ToLower() is not ("crispy" or "chewy" or "homemade"))
                { throw new ArgumentException("Invalid type of dough."); }
                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => weight;
            init 
            {if (value is < 1 or >200)
                { throw new ArgumentException("Dough weight should be in the range [1..200]."); }
                weight = value;
            }
        }
        public double CaloriesPerGram
        {
            get
            {
                double calPerGram = BaseCalories;
                if (flourType.ToLower() == "white")
                {
                    calPerGram *= 1.5;
                }
                else if (flourType.ToLower() == "wholegrain")
                { calPerGram *= 1.0; }
                switch (bakingTechnique.ToLower())
                {
                    case "crispy":calPerGram *= 0.9; break;
                    case "chewy": calPerGram *= 1.1; break;
                    case "homemade": calPerGram *= 1.0;break;

                }
                return calPerGram;
            }
        }
    }
}
