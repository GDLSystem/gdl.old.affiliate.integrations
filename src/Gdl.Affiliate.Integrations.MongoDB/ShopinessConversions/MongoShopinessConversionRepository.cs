using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Gdl.Affiliate.Integrations.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace Gdl.Affiliate.Integrations.ShopinessConversions
{
    public class MongoShopinessConversionRepository : MongoDbRepository<IntegrationsMongoDbContext, ShopinessConversion, Guid>, IShopinessConversionRepository
    {
        public MongoShopinessConversionRepository(IMongoDbContextProvider<IntegrationsMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<ShopinessConversion>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, conversionItemId, conversionId, status, saleAmountMin, saleAmountMax, payoutMin, payoutMax, payoutBonusMin, payoutBonusMax, conversionTimeMin, conversionTimeMax, platform, subId1, subId2, subId3, shopId, shortKey, shopName, productName, categoryName, campaign, isHappyDay);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShopinessConversionConsts.GetDefaultSorting(false) : sorting);
            return await query.As<IMongoQueryable<ShopinessConversion>>()
                .PageBy<ShopinessConversion, IMongoQueryable<ShopinessConversion>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
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
           CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, conversionItemId, conversionId, status, saleAmountMin, saleAmountMax, payoutMin, payoutMax, payoutBonusMin, payoutBonusMax, conversionTimeMin, conversionTimeMax, platform, subId1, subId2, subId3, shopId, shortKey, shopName, productName, categoryName, campaign, isHappyDay);
            return await query.As<IMongoQueryable<ShopinessConversion>>().LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ShopinessConversion> ApplyFilter(
            IQueryable<ShopinessConversion> query,
            string filterText,
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
            bool? isHappyDay = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ConversionItemId.Contains(filterText) || e.ConversionId.Contains(filterText) || e.Status.Contains(filterText) || e.Platform.Contains(filterText) || e.SubId1.Contains(filterText) || e.SubId2.Contains(filterText) || e.SubId3.Contains(filterText) || e.ShopId.Contains(filterText) || e.ShortKey.Contains(filterText) || e.ShopName.Contains(filterText) || e.ProductName.Contains(filterText) || e.CategoryName.Contains(filterText) || e.Campaign.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(conversionItemId), e => e.ConversionItemId.Contains(conversionItemId))
                    .WhereIf(!string.IsNullOrWhiteSpace(conversionId), e => e.ConversionId.Contains(conversionId))
                    .WhereIf(!string.IsNullOrWhiteSpace(status), e => e.Status.Contains(status))
                    .WhereIf(saleAmountMin.HasValue, e => e.SaleAmount >= saleAmountMin.Value)
                    .WhereIf(saleAmountMax.HasValue, e => e.SaleAmount <= saleAmountMax.Value)
                    .WhereIf(payoutMin.HasValue, e => e.Payout >= payoutMin.Value)
                    .WhereIf(payoutMax.HasValue, e => e.Payout <= payoutMax.Value)
                    .WhereIf(payoutBonusMin.HasValue, e => e.PayoutBonus >= payoutBonusMin.Value)
                    .WhereIf(payoutBonusMax.HasValue, e => e.PayoutBonus <= payoutBonusMax.Value)
                    .WhereIf(conversionTimeMin.HasValue, e => e.ConversionTime >= conversionTimeMin.Value)
                    .WhereIf(conversionTimeMax.HasValue, e => e.ConversionTime <= conversionTimeMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(platform), e => e.Platform.Contains(platform))
                    .WhereIf(!string.IsNullOrWhiteSpace(subId1), e => e.SubId1.Contains(subId1))
                    .WhereIf(!string.IsNullOrWhiteSpace(subId2), e => e.SubId2.Contains(subId2))
                    .WhereIf(!string.IsNullOrWhiteSpace(subId3), e => e.SubId3.Contains(subId3))
                    .WhereIf(!string.IsNullOrWhiteSpace(shopId), e => e.ShopId.Contains(shopId))
                    .WhereIf(!string.IsNullOrWhiteSpace(shortKey), e => e.ShortKey.Contains(shortKey))
                    .WhereIf(!string.IsNullOrWhiteSpace(shopName), e => e.ShopName.Contains(shopName))
                    .WhereIf(!string.IsNullOrWhiteSpace(productName), e => e.ProductName.Contains(productName))
                    .WhereIf(!string.IsNullOrWhiteSpace(categoryName), e => e.CategoryName.Contains(categoryName))
                    .WhereIf(!string.IsNullOrWhiteSpace(campaign), e => e.Campaign.Contains(campaign))
                    .WhereIf(isHappyDay.HasValue, e => e.IsHappyDay == isHappyDay);
        }
    }
}