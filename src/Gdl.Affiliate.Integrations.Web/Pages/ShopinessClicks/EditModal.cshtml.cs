using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Gdl.Affiliate.Integrations.ShopinessClicks;

namespace Gdl.Affiliate.Integrations.Web.Pages.ShopinessClicks
{
    public class EditModalModel : IntegrationsPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public ShopinessClickUpdateDto ShopinessClick { get; set; }

        private readonly IShopinessClicksAppService _shopinessClicksAppService;

        public EditModalModel(IShopinessClicksAppService shopinessClicksAppService)
        {
            _shopinessClicksAppService = shopinessClicksAppService;
        }

        public async Task OnGetAsync()
        {
            var shopinessClick = await _shopinessClicksAppService.GetAsync(Id);
            ShopinessClick = ObjectMapper.Map<ShopinessClickDto, ShopinessClickUpdateDto>(shopinessClick);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _shopinessClicksAppService.UpdateAsync(Id, ShopinessClick);
            return NoContent();
        }
    }
}