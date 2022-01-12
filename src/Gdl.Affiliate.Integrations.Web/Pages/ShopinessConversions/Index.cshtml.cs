using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Gdl.Affiliate.Integrations.ShopinessConversions;
using Gdl.Affiliate.Integrations.Shared;

namespace Gdl.Affiliate.Integrations.Web.Pages.ShopinessConversions
{
    public class IndexModel : AbpPageModel
    {
        public string ConversionItemIdFilter { get; set; }
        public string ConversionIdFilter { get; set; }
        public string StatusFilter { get; set; }
        public int? SaleAmountFilterMin { get; set; }

        public int? SaleAmountFilterMax { get; set; }
        public int? PayoutFilterMin { get; set; }

        public int? PayoutFilterMax { get; set; }
        public int? PayoutBonusFilterMin { get; set; }

        public int? PayoutBonusFilterMax { get; set; }
        public long? ConversionTimeFilterMin { get; set; }

        public long? ConversionTimeFilterMax { get; set; }
        public string PlatformFilter { get; set; }
        public string SubId1Filter { get; set; }
        public string SubId2Filter { get; set; }
        public string SubId3Filter { get; set; }
        public string ShopIdFilter { get; set; }
        public string ShortKeyFilter { get; set; }
        public string ShopNameFilter { get; set; }
        public string ProductNameFilter { get; set; }
        public string CategoryNameFilter { get; set; }
        public string CampaignFilter { get; set; }
        [SelectItems(nameof(IsHappyDayBoolFilterItems))]
        public string IsHappyDayFilter { get; set; }

        public List<SelectListItem> IsHappyDayBoolFilterItems { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("", ""),
                new SelectListItem("Yes", "true"),
                new SelectListItem("No", "false"),
            };

        private readonly IShopinessConversionsAppService _shopinessConversionsAppService;

        public IndexModel(IShopinessConversionsAppService shopinessConversionsAppService)
        {
            _shopinessConversionsAppService = shopinessConversionsAppService;
        }

        public async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}