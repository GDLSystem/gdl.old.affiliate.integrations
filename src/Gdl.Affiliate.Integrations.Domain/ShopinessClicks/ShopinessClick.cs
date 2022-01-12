using Gdl.Affiliate.Integrations.Core.Enums;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Gdl.Affiliate.Integrations.ShopinessClicks
{
    public class ShopinessClick : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual int Click { get; set; }

        public virtual AffiliateOwnershipType AffiliateOwnershipType { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public ShopinessClick()
        {

        }

        public ShopinessClick(Guid id, int click, AffiliateOwnershipType affiliateOwnershipType, DateTime createdAt)
        {
            Id = id;
            Click = click;
            AffiliateOwnershipType = affiliateOwnershipType;
            CreatedAt = createdAt;
        }
    }
}