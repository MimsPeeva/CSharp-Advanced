using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            switch (type)
            {
                case "Meat": return new Meat(quantity); break;
                case "Fruit": return new Fruit(quantity); break;
                case "Vegetable": return new Vegetable(quantity); break;
                case "Seeds": return new Seeds(quantity); break;
                default: throw new ArgumentException("Invalid food!"); break;
            }
        }
           
        }
}
