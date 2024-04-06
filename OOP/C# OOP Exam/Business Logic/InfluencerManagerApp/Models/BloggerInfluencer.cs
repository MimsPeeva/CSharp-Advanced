using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class BloggerInfluencer : Influencer
    {
        private const double engagement = 2.0;

        public BloggerInfluencer(string username, int followers) : base(username, followers, engagement)
        {
        }

        public override int CalculateCampaignPrice()
        {
            double result = Followers * EngagementRate * 0.2;
            int rounded = (int)Math.Floor(result);
            return rounded;
        }
    }
}
