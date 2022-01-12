using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Gdl.Affiliate.Integrations.ShopinessConversions;

namespace Gdl.Affiliate.Integrations.Web.Pages.ShopinessConversions
{
    public class EditModalModel : IntegrationsPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public ShopinessConversionUpdateDto ShopinessConversion { get; set; }

        private readonly IShopinessConversionsAppService _shopinessConversionsAppService;

        public EditModalModel(IShopinessConversionsAppService shopinessConversionsAppService)
        {
            _shopinessConversionsAppService = shopinessConversionsAppService;
        }

        public async Task OnGetAsync()
        {
            var shopinessConversion = await _shopinessConversionsAppService.GetAsync(Id);
            ShopinessConversion = ObjectMapper.Map<ShopinessConversionDto, ShopinessConversionUpdateDto>(shopinessConversion);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _shopinessConversionsAppService.UpdateAsync(Id, ShopinessConversion);
            return NoContent();
        }
    }
}