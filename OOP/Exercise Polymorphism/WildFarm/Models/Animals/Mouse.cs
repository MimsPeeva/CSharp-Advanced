using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override double WeightGain => 0.10;

        protected override string[] foodMenu => new string[] { "Vegetable", "Fruit" };

        public override string MakeSound()
        {
            return "Squeak";
        }
    }
}
