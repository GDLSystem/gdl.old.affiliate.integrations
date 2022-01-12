using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Gdl.Affiliate.Integrations.ShopinessConversions;

namespace Gdl.Affiliate.Integrations.Controllers.ShopinessConversions
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ShopinessConversion")]
    [Route("api/app/shopiness-conversions")]

    public class ShopinessConversionController : AbpController, IShopinessConversionsAppService
    {
        private readonly IShopinessConversionsAppService _shopinessConversionsAppService;

        public ShopinessConversionController(IShopinessConversionsAppService shopinessConversionsAppService)
        {
            _shopinessConversionsAppService = shopinessConversionsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ShopinessConversionDto>> GetListAsync(GetShopinessConversionsInput input)
        {
            return _shopinessConversionsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShopinessConversionDto> GetAsync(Guid id)
        {
            return _shopinessConversionsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ShopinessConversionDto> CreateAsync(ShopinessConversionCreateDto input)
        {
            return _shopinessConversionsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShopinessConversionDto> UpdateAsync(Guid id, ShopinessConversionUpdateDto input)
        {
            return _shopinessConversionsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shopinessConversionsAppService.DeleteAsync(id);
        }
    }
}