using Gdl.Affiliate.Integrations.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gdl.Affiliate.Integrations.ShopinessClicks
{
    public class ShopinessClickUpdateDto
    {
        [Required]
        public int Click { get; set; }
        public AffiliateOwnershipType AffiliateOwnershipType { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}