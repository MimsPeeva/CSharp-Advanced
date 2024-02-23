using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Trainer
{
    public class Trainer
    {
        private string name;
        private int numberOfBadges;
        public Trainer(string name, int numberOfBadges, List<Pokemon> pokemon)
        {
            Name = name;
            NumberOfBadges = numberOfBadges;
            Pokemon = pokemon;
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public int NumberOfBadges
        {
            set { numberOfBadges = value; }
            get { return numberOfBadges; }
        }
        public List<Pokemon> Pokemon { get; set; }


        public void CheckPokemon(string element)
        {
            if (Pokemon.Any(p => p.Element == element))
            {
                NumberOfBadges++;
            }
            else
            {
                for (int i = 0; i < Pokemon.Count; i++)
                {
                    Pokemon[i].Health -= 10;

                    if (Pokemon[i].Health <= 0)
                    {
                        Pokemon.Remove(Pokemon[i]);
                        i--;
                    }
                }
            }

        }
    }
}
