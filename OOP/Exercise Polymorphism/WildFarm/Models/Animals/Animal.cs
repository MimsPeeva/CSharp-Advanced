using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name
        {
            get;private set;
        }
        public double Weight
        {
            get; private set;

        }
        public int FoodEaten
        {
            get; private set;

        }
        protected abstract double WeightGain { get; }
        protected abstract string[] foodMenu { get; }
        public abstract string MakeSound();
        public void Eat(Food food)
        {
            if (foodMenu.Any(f => f == food.GetType().Name))
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * WeightGain;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }
    }
}
