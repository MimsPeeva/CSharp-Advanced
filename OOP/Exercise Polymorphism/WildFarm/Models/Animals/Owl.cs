using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        protected override double WeightGain => 0.25;
        protected override string[] foodMenu => new string[] { "Meat" };
        public override string MakeSound()
        {
            return "Hoot Hoot";
        }
    }
}
