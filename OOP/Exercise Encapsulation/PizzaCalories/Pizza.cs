using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                { throw new ArgumentException("Pizza name should be between 1 and 15 symbols."); }
                if (value.Length is < 1 or > 15)
                { throw new ArgumentException("Pizza name should be between 1 and 15 symbols."); }
                name = value;
            }
        }

        public  Dough Dough
        {
            get=>dough;
            set
            {
                dough = value;
            }
        }

        public void AddToppings(Topping topping)
        {
            if (toppings.Count == 10)
            { throw new ArgumentException("Number of toppings should be in range [0..10]."); }
            toppings.Add(topping);
        }
        public double TotalCalories
        {
            get
            {
                double total = this.Dough.CaloriesPerGram * this.Dough.Weight;
                foreach (var t in toppings)
                {
                    total += t.Weight * t.CaloriesPerGram();
                }
                return total;
            }
        }
    }
}
