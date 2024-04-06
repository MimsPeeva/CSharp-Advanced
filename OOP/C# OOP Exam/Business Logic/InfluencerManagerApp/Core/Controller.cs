using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Core
{
    public class Controller:IController
    {
        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }

        private IRepository<IInfluencer> influencers;
        private IRepository<ICampaign> campaigns;
        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (typeName is not ("BusinessInfluencer" or "FashionInfluencer" or "BloggerInfluencer"))
            {
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            if (influencers.FindByName(username) is not null)
            {
                return string.Format(OutputMessages.UsernameIsRegistered, username,influencers.GetType().Name);

            }

            IInfluencer influencer = null;
            if (typeName==typeof(BusinessInfluencer).Name)
            {
                influencer = new BusinessInfluencer(username, followers);
            }
            if (typeName == typeof(FashionInfluencer).Name)
            {
                influencer = new FashionInfluencer(username, followers);
            }
            if (typeName == typeof(BloggerInfluencer).Name)
            {
                influencer = new BloggerInfluencer(username, followers);
            }
            influencers.AddModel(influencer);
            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }

        public string BeginCampaign(string typeName, string brand)
        {
                ICampaign campaign = null;
            if (typeName is not ("ProductCampaign" or "ServiceCampaign"))
            {
                return string.Format(OutputMessages.CampaignTypeIsNotValid,typeName);
            }

            if (campaigns.FindByName(brand)is not null)
            {
                return string.Format(OutputMessages.CampaignDuplicated, brand);
            }

            if (typeName==typeof(ProductCampaign).Name)
            {
                campaign = new ProductCampaign(brand);
            }
            if (typeName == typeof(ServiceCampaign).Name)
            {
                campaign = new ServiceCampaign(brand);
            }
            campaigns.AddModel(campaign);
            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand,typeName);
        }

        public string AttractInfluencer(string brand, string username)
        {
            ICampaign curCampaign = null;
            IInfluencer currInfluencer = null;
            if ((currInfluencer = influencers.FindByName(username)) is null)
            {
                return string.Format(OutputMessages.InfluencerNotFound, influencers.GetType().Name, username);
            }

            if ((curCampaign = campaigns.FindByName(brand))is null)
            {
                return string.Format(OutputMessages.CampaignNotFound, brand);
            }

            if (campaigns.FindByName(brand)is not null)
            {
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            if ()
            {
                
            }

            if (curCampaign.Budget<currInfluencer.CalculateCampaignPrice())
            {
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            }
        }

        public string FundCampaign(string brand, double amount)
        {
            throw new NotImplementedException();
        }

        public string CloseCampaign(string brand)
        {
            throw new NotImplementedException();
        }

        public string ConcludeAppContract(string username)
        {
            throw new NotImplementedException();
        }

        public string ApplicationReport()
        {
            throw new NotImplementedException();
        }
    }
}
