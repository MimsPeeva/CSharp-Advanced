using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models.Animals
{
    public abstract class Mammal : Animal
    {
        public string LivingRegion { get; private set; }
        protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            LivingRegion = livingRegion;
        }
        public override string ToString() =>
           base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
