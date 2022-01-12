using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gdl.Affiliate.Integrations.ShopinessClicks;

namespace Gdl.Affiliate.Integrations.Web.Pages.ShopinessClicks
{
    public class CreateModalModel : IntegrationsPageModel
    {
        [BindProperty]
        public ShopinessClickCreateDto ShopinessClick { get; set; }

        private readonly IShopinessClicksAppService _shopinessClicksAppService;

        public CreateModalModel(IShopinessClicksAppService shopinessClicksAppService)
        {
            _shopinessClicksAppService = shopinessClicksAppService;
        }

        public async Task OnGetAsync()
        {
            ShopinessClick = new ShopinessClickCreateDto();
            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _shopinessClicksAppService.CreateAsync(ShopinessClick);
            return NoContent();
        }
    }
}