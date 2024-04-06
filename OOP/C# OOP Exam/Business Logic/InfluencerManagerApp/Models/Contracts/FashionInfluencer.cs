using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models.Contracts
{
    public class FashionInfluencer:Influencer
    {

        private const double engagement = 4.0;
        public FashionInfluencer(string username, int followers) : base(username, followers, engagement)
        {
        }

        public override int CalculateCampaignPrice()
        {
            double result = Followers * EngagementRate * 0.1;
            int rounded = (int)Math.Floor(result);
            return rounded;
        }
    }
}
