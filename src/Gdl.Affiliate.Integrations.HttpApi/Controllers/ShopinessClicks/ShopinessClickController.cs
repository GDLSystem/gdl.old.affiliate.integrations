using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Gdl.Affiliate.Integrations.ShopinessClicks;

namespace Gdl.Affiliate.Integrations.Controllers.ShopinessClicks
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ShopinessClick")]
    [Route("api/app/shopiness-clicks")]

    public class ShopinessClickController : AbpController, IShopinessClicksAppService
    {
        private readonly IShopinessClicksAppService _shopinessClicksAppService;

        public ShopinessClickController(IShopinessClicksAppService shopinessClicksAppService)
        {
            _shopinessClicksAppService = shopinessClicksAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ShopinessClickDto>> GetListAsync(GetShopinessClicksInput input)
        {
            return _shopinessClicksAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShopinessClickDto> GetAsync(Guid id)
        {
            return _shopinessClicksAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ShopinessClickDto> CreateAsync(ShopinessClickCreateDto input)
        {
            return _shopinessClicksAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShopinessClickDto> UpdateAsync(Guid id, ShopinessClickUpdateDto input)
        {
            return _shopinessClicksAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shopinessClicksAppService.DeleteAsync(id);
        }
    }
}