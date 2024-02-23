using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Beverage:Food
    {
        private double milliliters;

        public Beverage(string name, decimal price, double milliliters) : base(name, price)
        {
            this.milliliters = milliliters;
        }

        public double Milliliters { get; set; }
    }
}
