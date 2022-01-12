using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Gdl.Affiliate.Integrations.ShopinessConversions
{
    public class ShopinessConversion : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string ConversionItemId { get; set; }

        [NotNull]
        public virtual string ConversionId { get; set; }

        [CanBeNull]
        public virtual string Status { get; set; }

        public virtual int SaleAmount { get; set; }

        public virtual int Payout { get; set; }

        public virtual int PayoutBonus { get; set; }

        public virtual long ConversionTime { get; set; }

        [CanBeNull]
        public virtual string Platform { get; set; }

        [CanBeNull]
        public virtual string SubId1 { get; set; }

        [CanBeNull]
        public virtual string SubId2 { get; set; }

        [CanBeNull]
        public virtual string SubId3 { get; set; }

        [CanBeNull]
        public virtual string ShopId { get; set; }

        [CanBeNull]
        public virtual string ShortKey { get; set; }

        [CanBeNull]
        public virtual string ShopName { get; set; }

        [CanBeNull]
        public virtual string ProductName { get; set; }

        [CanBeNull]
        public virtual string CategoryName { get; set; }

        [CanBeNull]
        public virtual string Campaign { get; set; }

        public virtual bool IsHappyDay { get; set; }

        public ShopinessConversion()
        {

        }

        public ShopinessConversion(Guid id, string conversionItemId, string conversionId, string status, int saleAmount, int payout, int payoutBonus, long conversionTime, string platform, string subId1, string subId2, string subId3, string shopId, string shortKey, string shopName, string productName, string categoryName, string campaign, bool isHappyDay)
        {
            Id = id;
            Check.NotNull(conversionItemId, nameof(conversionItemId));
            Check.NotNull(conversionId, nameof(conversionId));
            ConversionItemId = conversionItemId;
            ConversionId = conversionId;
            Status = status;
            SaleAmount = saleAmount;
            Payout = payout;
            PayoutBonus = payoutBonus;
            ConversionTime = conversionTime;
            Platform = platform;
            SubId1 = subId1;
            SubId2 = subId2;
            SubId3 = subId3;
            ShopId = shopId;
            ShortKey = shortKey;
            ShopName = shopName;
            ProductName = productName;
            CategoryName = categoryName;
            Campaign = campaign;
            IsHappyDay = isHappyDay;
        }
    }
}