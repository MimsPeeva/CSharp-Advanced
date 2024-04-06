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
    public class Controller : IController
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
                return string.Format(OutputMessages.UsernameIsRegistered, username, influencers.GetType().Name);

            }

            IInfluencer influencer = null;
            if (typeName == typeof(BusinessInfluencer).Name)
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
                return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }

            if (campaigns.FindByName(brand) is not null)
            {
                return string.Format(OutputMessages.CampaignDuplicated, brand);
            }

            if (typeName == typeof(ProductCampaign).Name)
            {
                campaign = new ProductCampaign(brand);
            }

            if (typeName == typeof(ServiceCampaign).Name)
            {
                campaign = new ServiceCampaign(brand);
            }

            campaigns.AddModel(campaign);
            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string AttractInfluencer(string brand, string username)
        {
            ICampaign curCampaign = null;
            IInfluencer currInfluencer = null;
            bool eligible = false;
            if ((currInfluencer = influencers.FindByName(username)) is null)
            {
                return string.Format(OutputMessages.InfluencerNotFound, influencers.GetType().Name, username);
            }

            if ((curCampaign = campaigns.FindByName(brand)) is null)
            {
                return string.Format(OutputMessages.CampaignNotFound, brand);
            }
            if (curCampaign.Contributors.Contains(currInfluencer.Username))
            {
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            if (curCampaign.GetType().Name == nameof(ProductCampaign))
            {
                if (currInfluencer.GetType().Name == nameof(BusinessInfluencer) ||
                    currInfluencer.GetType().Name == nameof(FashionInfluencer))
                {
                    eligible = true;
                }
            }
            else if (curCampaign.GetType().Name == nameof(ServiceCampaign))
            {
                if (currInfluencer.GetType().Name == nameof(BusinessInfluencer) ||
                    currInfluencer.GetType().Name == nameof(BloggerInfluencer))
                {
                    eligible = true;
                }
            }

            if (!eligible)
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if (curCampaign.Budget < currInfluencer.CalculateCampaignPrice())
            {
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            currInfluencer.EarnFee(currInfluencer.CalculateCampaignPrice());
            currInfluencer.EnrollCampaign(brand);
            curCampaign.Engage(currInfluencer);
            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);


        }

        public string FundCampaign(string brand, double amount)
        {
            if (campaigns.FindByName(brand) is null)
            {
                return string.Format(OutputMessages.InvalidCampaignToFund);
            }

            if (amount <= 0)
            {
                return string.Format(OutputMessages.NotPositiveFundingAmount);
            }

            ICampaign currCampaign = campaigns.FindByName(brand);
            currCampaign.Gain(amount);
            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string CloseCampaign(string brand)
        {
            if (campaigns.FindByName(brand) == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToClose);
            }

            ICampaign currCampaign = campaigns.FindByName(brand);

            bool campaignBudgetCr = false;
            if (currCampaign.Budget > 10000)
            {
                campaignBudgetCr = true;
            }

            if (!campaignBudgetCr)
            {
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }

            if (campaignBudgetCr)
            {
                List<IInfluencer> currInfluencers = new List<IInfluencer>();
                foreach (string influencerName in currCampaign.Contributors)
                {
                    currInfluencers.Add(influencers.FindByName(influencerName));
                }

                foreach (IInfluencer influencer in currInfluencers)
                {
                    influencer.EarnFee(2000);
                    foreach (string campaignName in influencer.Participations)
                    {
                        if (currCampaign.Brand == campaignName)
                        {
                            influencer.EndParticipation(campaignName);
                            break;
                        }
                    }
                }
            }

            campaigns.RemoveModel(currCampaign);
            return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            if (influencers.FindByName(username) is null)
            {
                return string.Format(OutputMessages.InfluencerNotSigned, username);
            }

            IInfluencer currInfluencer = influencers.FindByName(username);
            if (currInfluencer.Participations.Count >= 1)
            {
                return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }

            influencers.RemoveModel(currInfluencer);
            return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();
            List<IInfluencer> sortedInfluencers = influencers.Models
                .OrderByDescending(i => i.Income)
                .ThenByDescending(i => i.Followers)
                .ToList();
            foreach (IInfluencer influencer in sortedInfluencers)
            {
                sb.AppendLine($"{influencer.ToString()}");
                if (influencer.Participations.Count > 0)
                {
                    sb.AppendLine("Active Campaigns:");
                    foreach (string campaignName in influencer.Participations)
                    {
                        ICampaign currentCampaign = campaigns.FindByName(campaignName);
                        sb.AppendLine($"--{currentCampaign.ToString()}");
                    }
                }
            }

            return sb.ToString().Trim();
        }
    }
}