using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver:IDiver
    {
        protected Diver(string name, int oxygenLevel)
        {
            this.name = name;
            this.oxygenLevel = oxygenLevel;
            caughtFish = new List<string>();
            //competitionPoints = 0;
           // hasHealthIssues = false;
        }

        private string name;
        private int oxygenLevel;
        private List<string> caughtFish;
        private double competitionPoints;
        private bool hasHealthIssues;
        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }

                name = value;
            }
        }

        public int OxygenLevel
        {
            get=> oxygenLevel;
            protected set
            {
                if (value <= 0)
                {
                    hasHealthIssues = true;
                    value = 0;
                }
                oxygenLevel = value;
            }
        }
        public IReadOnlyCollection<string> Catch => caughtFish.AsReadOnly(); 

        public double CompetitionPoints
        {
            get => competitionPoints;
            private set
            {
               competitionPoints = value;
            }
        }

        public bool HasHealthIssues
        {
            get=>hasHealthIssues;
            private set =>hasHealthIssues = value;
        }
        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            caughtFish.Add(fish.Name);
            CompetitionPoints = Math.Round(competitionPoints + fish.Points,1);
        }

        public abstract void Miss(int timeToCatch);


        public void UpdateHealthStatus()
        {
            HasHealthIssues = !HasHealthIssues;
        }


        public abstract void RenewOxy();
        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {caughtFish.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
