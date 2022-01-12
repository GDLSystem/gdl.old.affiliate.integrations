using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Gdl.Affiliate.Integrations.ShopinessConversions
{
    public interface IShopinessConversionRepository : IRepository<ShopinessConversion, Guid>
    {
        Task<List<ShopinessConversion>> GetListAsync(
            string filterText = null,
            string conversionItemId = null,
            string conversionId = null,
            string status = null,
            int? saleAmountMin = null,
            int? saleAmountMax = null,
            int? payoutMin = null,
            int? payoutMax = null,
            int? payoutBonusMin = null,
            int? payoutBonusMax = null,
            long? conversionTimeMin = null,
            long? conversionTimeMax = null,
            string platform = null,
            string subId1 = null,
            string subId2 = null,
            string subId3 = null,
            string shopId = null,
            string shortKey = null,
            string shopName = null,
            string productName = null,
            string categoryName = null,
            string campaign = null,
            bool? isHappyDay = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string conversionItemId = null,
            string conversionId = null,
            string status = null,
            int? saleAmountMin = null,
            int? saleAmountMax = null,
            int? payoutMin = null,
            int? payoutMax = null,
            int? payoutBonusMin = null,
            int? payoutBonusMax = null,
            long? conversionTimeMin = null,
            long? conversionTimeMax = null,
            string platform = null,
            string subId1 = null,
            string subId2 = null,
            string subId3 = null,
            string shopId = null,
            string shortKey = null,
            string shopName = null,
            string productName = null,
            string categoryName = null,
            string campaign = null,
            bool? isHappyDay = null,
            CancellationToken cancellationToken = default);
    }
}