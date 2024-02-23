using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake:Dessert
    {
        public Cake(string name, decimal price, double grams, double calories) : base(name, price, grams, calories)
        {
            grams = 250;
            calories = 1000;
            price = 5;
        }
    }
}
