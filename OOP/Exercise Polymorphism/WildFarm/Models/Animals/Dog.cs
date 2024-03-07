using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override double WeightGain => 0.4;

        protected override string[] foodMenu => new string[] { "Meat" };

        public override string MakeSound()
        {
            return "Woof!";
        }
    }
}
