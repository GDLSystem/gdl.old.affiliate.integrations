using Gdl.Affiliate.Integrations.Core.Enums;
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

namespace Gdl.Affiliate.Integrations.ShopinessClicks
{
    public class MongoShopinessClickRepository : MongoDbRepository<IntegrationsMongoDbContext, ShopinessClick, Guid>, IShopinessClickRepository
    {
        public MongoShopinessClickRepository(IMongoDbContextProvider<IntegrationsMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<ShopinessClick>> GetListAsync(
            string filterText = null,
            int? clickMin = null,
            int? clickMax = null,
            AffiliateOwnershipType? affiliateOwnershipType = null,
            DateTime? createdAtMin = null,
            DateTime? createdAtMax = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, clickMin, clickMax, affiliateOwnershipType, createdAtMin, createdAtMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShopinessClickConsts.GetDefaultSorting(false) : sorting);
            return await query.As<IMongoQueryable<ShopinessClick>>()
                .PageBy<ShopinessClick, IMongoQueryable<ShopinessClick>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
           string filterText = null,
           int? clickMin = null,
           int? clickMax = null,
           AffiliateOwnershipType? affiliateOwnershipType = null,
           DateTime? createdAtMin = null,
           DateTime? createdAtMax = null,
           CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, clickMin, clickMax, affiliateOwnershipType, createdAtMin, createdAtMax);
            return await query.As<IMongoQueryable<ShopinessClick>>().LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ShopinessClick> ApplyFilter(
            IQueryable<ShopinessClick> query,
            string filterText,
            int? clickMin = null,
            int? clickMax = null,
            AffiliateOwnershipType? affiliateOwnershipType = null,
            DateTime? createdAtMin = null,
            DateTime? createdAtMax = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(clickMin.HasValue, e => e.Click >= clickMin.Value)
                    .WhereIf(clickMax.HasValue, e => e.Click <= clickMax.Value)
                    .WhereIf(affiliateOwnershipType.HasValue, e => e.AffiliateOwnershipType == affiliateOwnershipType)
                    .WhereIf(createdAtMin.HasValue, e => e.CreatedAt >= createdAtMin.Value)
                    .WhereIf(createdAtMax.HasValue, e => e.CreatedAt <= createdAtMax.Value);
        }
    }
}