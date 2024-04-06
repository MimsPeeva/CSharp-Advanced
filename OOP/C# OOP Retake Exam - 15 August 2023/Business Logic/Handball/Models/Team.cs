using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Handball.Models.Contracts;

namespace Handball.Models
{
    public class Team:ITeam
    {
        public Team(string name)
        {
            Name = name;
            PointsEarned = 0;
            
            players = new List<IPlayer>();
        }

        private string name;
        private int pointsEarned;
        private List<IPlayer> players;

        public string Name
        {
            get=>name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Team name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int PointsEarned
        {
            get => pointsEarned;
            private set { pointsEarned = value; }

        }

        public double OverallRating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                
                 return   Math.Round(Players.Average(p => p.Rating), 2);
                
            }
        }

        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();
        
        public void SignContract(IPlayer player)
        {
            players.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3;
            foreach (var player in players)
            {
                player.IncreaseRating();
            }
        }

        public void Lose()
        {
            foreach (var player in players)
            {
                player.DecreaseRating();
            }
        }

        public void Draw()
        {
            pointsEarned += 1;
            this.Players.FirstOrDefault(p => p.GetType().Name == nameof(Goalkeeper)).IncreaseRating();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            sb.Append("--Players: ");
            if (players.Count != 0)
            {
                sb.Append(string.Join(", ", players.Select(p => p.Name)));
            }
            else sb.Append("none");
            return sb.ToString().Trim();
        }
    }
}
