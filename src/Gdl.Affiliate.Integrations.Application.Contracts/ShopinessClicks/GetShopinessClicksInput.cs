using Gdl.Affiliate.Integrations.Core.Enums;
using Volo.Abp.Application.Dtos;
using System;

namespace Gdl.Affiliate.Integrations.ShopinessClicks
{
    public class GetShopinessClicksInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public int? ClickMin { get; set; }
        public int? ClickMax { get; set; }
        public AffiliateOwnershipType? AffiliateOwnershipType { get; set; }
        public DateTime? CreatedAtMin { get; set; }
        public DateTime? CreatedAtMax { get; set; }

        public GetShopinessClicksInput()
        {

        }
    }
}