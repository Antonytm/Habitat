﻿namespace Sitecore.Feature.Demo.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Sitecore.Analytics;
    using Sitecore.Feature.Demo.Models;

    public class ReferralRepository
    {
        private readonly ICampaignRepository campaignRepository;

        public ReferralRepository(ICampaignRepository campaignRepository)
        {
            this.campaignRepository = campaignRepository;
        }

        public ReferralRepository() : this(new CampaignRepository())
        {
        }

        public Referral Get()
        {
            var campaigns = this.CreateCampaigns().ToArray();
            var referringSite = Tracker.Current.Interaction.ReferringSite;
            if (referringSite.Equals(HttpContext.Current.Request.Url.Host, StringComparison.InvariantCultureIgnoreCase))
            {
                referringSite = null;
            }
            return new Referral
            {
                Campaigns = campaigns,
                TotalNoOfCampaigns = campaigns.Length,
                ReferringSite = referringSite,
                Keywords = Tracker.Current.Interaction.Keywords
            };
        }

        private IEnumerable<Campaign> CreateCampaigns()
        {
            var activeCampaign = this.GetActiveCampaign();
            if (activeCampaign != null)
            {
                yield return activeCampaign;
            }

            foreach (var campaign in this.GetHistoricCampaigns())
            {
                yield return campaign;
            }
        }

        private IEnumerable<Campaign> GetHistoricCampaigns()
        {
            return this.campaignRepository.GetHistoric();
        }

        private Campaign GetActiveCampaign()
        {
            return this.campaignRepository.GetCurrent();
        }
    }
}