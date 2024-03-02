using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage.Models
{
    public class Citizen:IIdentifiable,IBirthdatable, IBuyer
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public int Food { get; private set; } = 0;

        public DateOnly BirthDate { get; private set; }

        public Citizen(string name, int age, string id, DateOnly birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthdate;
        }

        public void BuyFood()
        {
            Food += 10;
        }
    }

}
