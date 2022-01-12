using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Gdl.Affiliate.Integrations.ShopinessClicks
{
    public interface IShopinessClicksAppService : IApplicationService
    {
        Task<PagedResultDto<ShopinessClickDto>> GetListAsync(GetShopinessClicksInput input);

        Task<ShopinessClickDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ShopinessClickDto> CreateAsync(ShopinessClickCreateDto input);

        Task<ShopinessClickDto> UpdateAsync(Guid id, ShopinessClickUpdateDto input);
    }
}