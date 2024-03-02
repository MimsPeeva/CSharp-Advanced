using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> bagOfProducts;
        public List<Product> BagOfProducts => bagOfProducts;
        
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
           bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => name;
            init 
            {
                if (string.IsNullOrWhiteSpace(value))
                { throw new ArgumentException("Name cannot be empty"); }
                name = value;
            }
           
        }
        public int Money
        {
            get => money;
            set
            {
                if (value<0)
                { throw new ArgumentException("Money cannot be negative"); }
                money = value;
            }

        }

        public void AddProduct(Product product)
        {
            if (product.Cost > Money)
            {
              throw new ArgumentException($"{Name} can't afford {product.Name}");
            }
                bagOfProducts.Add(product);
                Money -= product.Cost;
        }
    }
}
