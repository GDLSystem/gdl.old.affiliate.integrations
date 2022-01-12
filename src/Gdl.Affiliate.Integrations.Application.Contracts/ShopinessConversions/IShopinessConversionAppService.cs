using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Gdl.Affiliate.Integrations.ShopinessConversions
{
    public interface IShopinessConversionsAppService : IApplicationService
    {
        Task<PagedResultDto<ShopinessConversionDto>> GetListAsync(GetShopinessConversionsInput input);

        Task<ShopinessConversionDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ShopinessConversionDto> CreateAsync(ShopinessConversionCreateDto input);

        Task<ShopinessConversionDto> UpdateAsync(Guid id, ShopinessConversionUpdateDto input);
    }
}