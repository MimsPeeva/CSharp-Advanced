using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Animal
    {
        public string Name { get; protected set; }
        public string FavouriteFood { get; protected set; }

        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my fovourite food is {FavouriteFood}";
        }
    }
}
