using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models.Contracts;

namespace InfluencerManagerApp.Models
{
    public class ProductCampaign:Campaign
    {
        private const double budget = 60000;
        public ProductCampaign(string brand) : base(brand, budget)
        {
        }
    }
}
