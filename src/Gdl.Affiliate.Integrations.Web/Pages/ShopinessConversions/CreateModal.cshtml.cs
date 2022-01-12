using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gdl.Affiliate.Integrations.ShopinessConversions;

namespace Gdl.Affiliate.Integrations.Web.Pages.ShopinessConversions
{
    public class CreateModalModel : IntegrationsPageModel
    {
        [BindProperty]
        public ShopinessConversionCreateDto ShopinessConversion { get; set; }

        private readonly IShopinessConversionsAppService _shopinessConversionsAppService;

        public CreateModalModel(IShopinessConversionsAppService shopinessConversionsAppService)
        {
            _shopinessConversionsAppService = shopinessConversionsAppService;
        }

        public async Task OnGetAsync()
        {
            ShopinessConversion = new ShopinessConversionCreateDto();
            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _shopinessConversionsAppService.CreateAsync(ShopinessConversion);
            return NoContent();
        }
    }
}