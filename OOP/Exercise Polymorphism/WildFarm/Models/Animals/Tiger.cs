using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightGain => 1.00;

        protected override string[] foodMenu => new string[] { "Meat" };

        public override string MakeSound()
        {
            return "ROAR!!!";
        }
    }
}
