using System;
using System.Threading.Tasks;

namespace Gdl.Affiliate.Integrations.ConsoleApp.Jobs
{
    public class SyncShopinessStatisticAffJob : BackgroundJobBase
    {
        // private readonly IAffiliateConversionDomainService _affiliateConversionDomainService;
        //
        // public SyncShopinessStatisticAffJob(IAffiliateConversionDomainService affiliateConversionDomainService)
        // {
        //     _affiliateConversionDomainService = affiliateConversionDomainService;
        // }

        protected override async Task DoExecute()
        {
            var now = DateTime.UtcNow.Date.AddHours(DateTime.UtcNow.Hour);
            //
            // await _affiliateConversionDomainService.SyncAffStats(3, AffiliateOwnershipType.GDL, now.AddHours(-2), now);
            //
            // await Task.Delay(3000);
            //
            // await _affiliateConversionDomainService.SyncAffStats(3, AffiliateOwnershipType.HappyDay, now.AddHours(-2), now);
        }
    }
}