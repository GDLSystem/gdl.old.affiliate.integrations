using System;
using Gdl.Affiliate.Integrations.Core.Enums;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Gdl.Affiliate.Integrations.UserAffiliates
{
    public class UserAffiliate : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }
        public MarketplaceType MarketplaceType { get; set; }
        /// <summary>
        /// TIKI or Shopiness for now (10.2021)
        /// </summary>
        public AffiliateProviderType AffiliateProviderType { get; set; }
        public AffiliateOwnershipType AffiliateOwnershipType { get; set; }
        public string Url { get; set; }
        public string AffiliateUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? AppUserId { get; set; }
        public AffConversionModel AffConversionModel { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? GroupId { get; set; }
        public Guid? PartnerId { get; set; }
        public Guid? CampaignId { get; set; }

        public UserAffiliate()
        {
            AffConversionModel = new AffConversionModel();
        }
    }
    public class AffConversionModel
    {
        public int ClickCount { get; set; }
        public int ConversionCount { get; set; }
        public decimal ConversionAmount { get; set; }
        public decimal CommissionAmount { get; set; }
        public decimal CommissionBonusAmount { get; set; }
    }
}
