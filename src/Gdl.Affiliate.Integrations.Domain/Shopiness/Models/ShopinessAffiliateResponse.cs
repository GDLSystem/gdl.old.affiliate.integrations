using System;
using System.Collections.Generic;
using Gdl.Affiliate.Integrations.Core.Const;
using Gdl.Affiliate.Integrations.Core.Extensions;

namespace Gdl.Affiliate.Integrations.Shopiness.Models
{

    public class ShopinessPayloadTrackingResponse
    {
        public string CustomLink { get; set; }
        public string ShortKey { get; set; }
    }

    public class ShopinessPayloadStatisticResponse
    {
        public string Date { get; set; }
        public DateTime? DateValue => (this.Date.IsNotNullOrEmpty()) ? DateTime.ParseExact(this.Date,GlobalConsts.DateFormat, null) : DateValue;
        public List<ShopinessAffiliateStatistic> ListData { get; set; }
    }

    public class ShopinessAffiliateStatistic
    {
        public int Conversion { get; set; }
        public decimal Value { get; set; }
        public decimal Commission { get; set; }
        public decimal CommissionBonus { get; set; }
        public int Click { get; set; }
        public string Key { get; set; }
    }

    public class ShopinessPayloadConversionsResponse
    {
        public ShopinessPayloadConversionsResponse()
        {
            ListData = new List<ShopinessConversionResponse>();
        }
        public List<ShopinessConversionResponse> ListData { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
    
    public class ShopinessConversionResponse
    {
        public string ConversionItemId { get; set; }
        public string ConversionId { get; set; }
        public string Status { get; set; }
        public int SaleAmount { get; set; }
        public int Payout { get; set; }
        public int PayoutBonus { get; set; }
        public long ConversionTime { get; set; }
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
    }
}
