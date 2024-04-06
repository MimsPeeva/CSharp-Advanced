using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models.Contracts
{
    public class BusinessInfluencer:Influencer
    {
        private const double engagement = 3.0;
        public BusinessInfluencer(string username, int followers) : base(username, followers, engagement)
        {
        }

        public override int CalculateCampaignPrice()
        {
          double result =  Followers * EngagementRate * 0.15;
           int rounded = (int)Math.Round(result);
           return rounded;
        }
    }
}
