
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Trainer
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public Pokemon(string name, string element, int health)
        {
            this.name = name;
            this.element = element;
            this.health = health;
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string Element
        {
            set { element = value; }
            get { return element; }
        }
        public int Health
        {
            set { health = value; }
            get { return health; }
        }
    }
}
