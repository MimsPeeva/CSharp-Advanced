using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models.Contracts
{
    public class Campaign:ICampaign
    {
        public Campaign(string brand, double budget)
        {
            Brand = brand;
            Budget = budget;
            contributors = new List<string>();
        }

        private string brand;
        private double budget;
        private List<string> contributors;

        public string Brand
        {
            get=>brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandIsrequired);
                }
                brand = value;
            }
        }

        public double Budget
        {
            get=>budget;
            private set { budget = value; }
        }
        public IReadOnlyCollection<string> Contributors => contributors;
        public void Gain(double amount)
        {
           Budget+=amount;
        }

        public void Engage(IInfluencer influencer)
        {
            contributors.Add(influencer.Username);
           int amount =  influencer.CalculateCampaignPrice();
           Budget -= amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {Contributors.Count}";
        }
    }
}
