using Gdl.Affiliate.Integrations.Core.Enums;
using System;
using Volo.Abp.Application.Dtos;

namespace Gdl.Affiliate.Integrations.ShopinessClicks
{
    public class ShopinessClickDto : EntityDto<Guid>
    {
        public int Click { get; set; }
        public AffiliateOwnershipType AffiliateOwnershipType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}