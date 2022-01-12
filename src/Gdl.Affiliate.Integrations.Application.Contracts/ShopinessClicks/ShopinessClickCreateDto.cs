using Gdl.Affiliate.Integrations.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gdl.Affiliate.Integrations.ShopinessClicks
{
    public class ShopinessClickCreateDto
    {
        [Required]
        public int Click { get; set; }
        public AffiliateOwnershipType AffiliateOwnershipType { get; set; } = ((AffiliateOwnershipType[])Enum.GetValues(typeof(AffiliateOwnershipType)))[0];
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}