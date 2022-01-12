using Gdl.Affiliate.Integrations.Core.Enums;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Gdl.Affiliate.Integrations.ShopinessClicks
{
    public interface IShopinessClickRepository : IRepository<ShopinessClick, Guid>
    {
        Task<List<ShopinessClick>> GetListAsync(
            string filterText = null,
            int? clickMin = null,
            int? clickMax = null,
            AffiliateOwnershipType? affiliateOwnershipType = null,
            DateTime? createdAtMin = null,
            DateTime? createdAtMax = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            int? clickMin = null,
            int? clickMax = null,
            AffiliateOwnershipType? affiliateOwnershipType = null,
            DateTime? createdAtMin = null,
            DateTime? createdAtMax = null,
            CancellationToken cancellationToken = default);
    }
}