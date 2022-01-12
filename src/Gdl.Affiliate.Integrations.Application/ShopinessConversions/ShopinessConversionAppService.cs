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
using Gdl.Affiliate.Integrations.ShopinessConversions;

namespace Gdl.Affiliate.Integrations.ShopinessConversions
{
    [RemoteService(IsEnabled = false)]
    [Authorize(IntegrationsPermissions.ShopinessConversions.Default)]
    public class ShopinessConversionsAppService : ApplicationService, IShopinessConversionsAppService
    {
        private readonly IShopinessConversionRepository _shopinessConversionRepository;

        public ShopinessConversionsAppService(IShopinessConversionRepository shopinessConversionRepository)
        {
            _shopinessConversionRepository = shopinessConversionRepository;
        }

        public virtual async Task<PagedResultDto<ShopinessConversionDto>> GetListAsync(GetShopinessConversionsInput input)
        {
            var totalCount = await _shopinessConversionRepository.GetCountAsync(input.FilterText, input.ConversionItemId, input.ConversionId, input.Status, input.SaleAmountMin, input.SaleAmountMax, input.PayoutMin, input.PayoutMax, input.PayoutBonusMin, input.PayoutBonusMax, input.ConversionTimeMin, input.ConversionTimeMax, input.Platform, input.SubId1, input.SubId2, input.SubId3, input.ShopId, input.ShortKey, input.ShopName, input.ProductName, input.CategoryName, input.Campaign, input.IsHappyDay);
            var items = await _shopinessConversionRepository.GetListAsync(input.FilterText, input.ConversionItemId, input.ConversionId, input.Status, input.SaleAmountMin, input.SaleAmountMax, input.PayoutMin, input.PayoutMax, input.PayoutBonusMin, input.PayoutBonusMax, input.ConversionTimeMin, input.ConversionTimeMax, input.Platform, input.SubId1, input.SubId2, input.SubId3, input.ShopId, input.ShortKey, input.ShopName, input.ProductName, input.CategoryName, input.Campaign, input.IsHappyDay, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShopinessConversionDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShopinessConversion>, List<ShopinessConversionDto>>(items)
            };
        }

        public virtual async Task<ShopinessConversionDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShopinessConversion, ShopinessConversionDto>(await _shopinessConversionRepository.GetAsync(id));
        }

        [Authorize(IntegrationsPermissions.ShopinessConversions.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shopinessConversionRepository.DeleteAsync(id);
        }

        [Authorize(IntegrationsPermissions.ShopinessConversions.Create)]
        public virtual async Task<ShopinessConversionDto> CreateAsync(ShopinessConversionCreateDto input)
        {

            var shopinessConversion = ObjectMapper.Map<ShopinessConversionCreateDto, ShopinessConversion>(input);
            shopinessConversion.TenantId = CurrentTenant.Id;
            shopinessConversion = await _shopinessConversionRepository.InsertAsync(shopinessConversion, autoSave: true);
            return ObjectMapper.Map<ShopinessConversion, ShopinessConversionDto>(shopinessConversion);
        }

        [Authorize(IntegrationsPermissions.ShopinessConversions.Edit)]
        public virtual async Task<ShopinessConversionDto> UpdateAsync(Guid id, ShopinessConversionUpdateDto input)
        {

            var shopinessConversion = await _shopinessConversionRepository.GetAsync(id);
            ObjectMapper.Map(input, shopinessConversion);
            shopinessConversion = await _shopinessConversionRepository.UpdateAsync(shopinessConversion, autoSave: true);
            return ObjectMapper.Map<ShopinessConversion, ShopinessConversionDto>(shopinessConversion);
        }
    }
}