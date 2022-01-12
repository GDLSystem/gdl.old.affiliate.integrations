using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Gdl.Affiliate.Integrations.Permissions;
using Gdl.Affiliate.Integrations.ShopinessClicks;

namespace Gdl.Affiliate.Integrations.ShopinessClicks
{
    [RemoteService(IsEnabled = false)]
    [Authorize(IntegrationsPermissions.ShopinessClicks.Default)]
    public class ShopinessClicksAppService : ApplicationService, IShopinessClicksAppService
    {
        private readonly IShopinessClickRepository _shopinessClickRepository;

        public ShopinessClicksAppService(IShopinessClickRepository shopinessClickRepository)
        {
            _shopinessClickRepository = shopinessClickRepository;
        }

        public virtual async Task<PagedResultDto<ShopinessClickDto>> GetListAsync(GetShopinessClicksInput input)
        {
            var totalCount = await _shopinessClickRepository.GetCountAsync(input.FilterText, input.ClickMin, input.ClickMax, input.AffiliateOwnershipType, input.CreatedAtMin, input.CreatedAtMax);
            var items = await _shopinessClickRepository.GetListAsync(input.FilterText, input.ClickMin, input.ClickMax, input.AffiliateOwnershipType, input.CreatedAtMin, input.CreatedAtMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShopinessClickDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShopinessClick>, List<ShopinessClickDto>>(items)
            };
        }

        public virtual async Task<ShopinessClickDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShopinessClick, ShopinessClickDto>(await _shopinessClickRepository.GetAsync(id));
        }

        [Authorize(IntegrationsPermissions.ShopinessClicks.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shopinessClickRepository.DeleteAsync(id);
        }

        [Authorize(IntegrationsPermissions.ShopinessClicks.Create)]
        public virtual async Task<ShopinessClickDto> CreateAsync(ShopinessClickCreateDto input)
        {

            var shopinessClick = ObjectMapper.Map<ShopinessClickCreateDto, ShopinessClick>(input);
            shopinessClick.TenantId = CurrentTenant.Id;
            shopinessClick = await _shopinessClickRepository.InsertAsync(shopinessClick, autoSave: true);
            return ObjectMapper.Map<ShopinessClick, ShopinessClickDto>(shopinessClick);
        }

        [Authorize(IntegrationsPermissions.ShopinessClicks.Edit)]
        public virtual async Task<ShopinessClickDto> UpdateAsync(Guid id, ShopinessClickUpdateDto input)
        {

            var shopinessClick = await _shopinessClickRepository.GetAsync(id);
            ObjectMapper.Map(input, shopinessClick);
            shopinessClick = await _shopinessClickRepository.UpdateAsync(shopinessClick, autoSave: true);
            return ObjectMapper.Map<ShopinessClick, ShopinessClickDto>(shopinessClick);
        }
    }
}