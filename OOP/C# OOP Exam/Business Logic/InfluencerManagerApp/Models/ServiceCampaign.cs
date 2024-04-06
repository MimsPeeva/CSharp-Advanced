using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models.Contracts;

namespace InfluencerManagerApp.Models
{
    public class ServiceCampaign:Campaign
    {
        private const double budget = 30000;

        public ServiceCampaign(string brand) : base(brand, budget)
        {
        }
    }
}
