using Gdl.Affiliate.Integrations.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Gdl.Affiliate.Integrations.ShopinessClicks;
using Gdl.Affiliate.Integrations.Shared;

namespace Gdl.Affiliate.Integrations.Web.Pages.ShopinessClicks
{
    public class IndexModel : AbpPageModel
    {
        public int? ClickFilterMin { get; set; }

        public int? ClickFilterMax { get; set; }
        public AffiliateOwnershipType? AffiliateOwnershipTypeFilter { get; set; }
        public DateTime? CreatedAtFilterMin { get; set; }

        public DateTime? CreatedAtFilterMax { get; set; }

        private readonly IShopinessClicksAppService _shopinessClicksAppService;

        public IndexModel(IShopinessClicksAppService shopinessClicksAppService)
        {
            _shopinessClicksAppService = shopinessClicksAppService;
        }

        public async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}