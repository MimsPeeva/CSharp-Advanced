using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightGain => 0.3;

        protected override string[] foodMenu => new string[] { "Vegetable", "Meat" };

        public override string MakeSound()
        {
            return "Meow";
        }
    }
}
