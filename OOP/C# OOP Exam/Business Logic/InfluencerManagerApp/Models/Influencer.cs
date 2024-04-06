using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer:IInfluencer
    {
        protected Influencer(string username, int followers, double engagementRate)
        {
            this.username = username;
            this.followers = followers;
            this.engagementRate = engagementRate;
            Income = 0;
            participations = new List<string>();
        }

        private string username;
        private int followers;
        private double engagementRate;
        private double income;
        private List<string> participations;
        public string Username
        { 
            get=>username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
                }
                username = value;
            }
        }

        public int Followers
        {
            get=>followers;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
                }
                followers = value;
            }
        }

        public double EngagementRate
        {
            get=>engagementRate;
            private set { engagementRate = value; }
        }

        public double Income
        {
            get=>income;
            private set { income = value; }
        }
        public IReadOnlyCollection<string> Participations => participations;

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }

        public void EarnFee(double amount)
        {
           Income+=amount;
        }

        public void EnrollCampaign(string brand)
        {
            participations.Add(brand);
        }

        public void EndParticipation(string brand)
        {
            participations.Remove(brand);
        }

        public abstract int CalculateCampaignPrice();
      
    }
}
