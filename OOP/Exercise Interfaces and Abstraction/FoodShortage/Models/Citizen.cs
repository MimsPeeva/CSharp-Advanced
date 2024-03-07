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
        public string Name { get;  set; }
        public int Age { get;  set; }
        public string Id { get; set; }
        public int Food { get;private set; } 

        public string BirthDate { get; set; }

        public Citizen(string name, int age, string id, string birthdate)
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
