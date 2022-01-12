using Volo.Abp.Application.Dtos;
using System;

namespace Gdl.Affiliate.Integrations.ShopinessConversions
{
    public class GetShopinessConversionsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string ConversionItemId { get; set; }
        public string ConversionId { get; set; }
        public string Status { get; set; }
        public int? SaleAmountMin { get; set; }
        public int? SaleAmountMax { get; set; }
        public int? PayoutMin { get; set; }
        public int? PayoutMax { get; set; }
        public int? PayoutBonusMin { get; set; }
        public int? PayoutBonusMax { get; set; }
        public long? ConversionTimeMin { get; set; }
        public long? ConversionTimeMax { get; set; }
        public string Platform { get; set; }
        public string SubId1 { get; set; }
        public string SubId2 { get; set; }
        public string SubId3 { get; set; }
        public string ShopId { get; set; }
        public string ShortKey { get; set; }
        public string ShopName { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Campaign { get; set; }
        public bool? IsHappyDay { get; set; }

        public GetShopinessConversionsInput()
        {

        }
    }
}