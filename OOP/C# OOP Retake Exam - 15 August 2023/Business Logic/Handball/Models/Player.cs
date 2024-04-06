using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models
{
    public abstract class Player:IPlayer
    {
        public Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }

        private string name;
        private double rating;
        private string team;
        public string Name
        {
            get=>name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player name cannot be null or empty.");
                }
                name = value;
            }
        }

        public double Rating
        {
            get=>rating;
            protected set
            {
                if (value > 10)
                {
                    rating = 10;
                    
                }

              else  if (value < 1)
                {
                    rating = 1;
                }

               else rating = value;

            }
        }
        public string Team =>team; 
        public void JoinTeam(string name)
        {
            team = name;
        }

        public abstract void IncreaseRating();

        public abstract void DecreaseRating();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}: {name}");
            sb.AppendLine($"--Rating: {rating}");
            return sb.ToString().Trim();
        }
    }
}
