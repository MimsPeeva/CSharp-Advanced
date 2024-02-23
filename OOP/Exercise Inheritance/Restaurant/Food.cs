using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Food
    {
        public Food(string name, decimal price, double grams)
        {
            Name = name;
            Price = price;
            Grams = grams;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Grams { get; set; }
    }
}
