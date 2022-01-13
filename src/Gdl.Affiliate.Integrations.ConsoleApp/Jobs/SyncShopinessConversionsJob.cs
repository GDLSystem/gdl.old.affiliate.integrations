using System;
using System.Threading.Tasks;
using Gdl.Affiliate.Integrations.AffiliateConversions;
using Gdl.Affiliate.Integrations.Core.Enums;
using Gdl.Affiliate.Integrations.UserAffiliates;

namespace Gdl.Affiliate.Integrations.ConsoleApp.Jobs
{
    public class SyncShopinessConversionsJob : BackgroundJobBase
    {
        private readonly IAffiliateConversionDomainService _conversionDomainService;
        private readonly IUserAffiliateDomainService _userAffiliateDomainService;
        
        public SyncShopinessConversionsJob(IAffiliateConversionDomainService conversionDomainService, IUserAffiliateDomainService userAffiliateDomainService)
        {
            _conversionDomainService = conversionDomainService;
            _userAffiliateDomainService = userAffiliateDomainService;
        }

        protected override async Task DoExecute()
        {
            var now = DateTime.UtcNow;
            await _userAffiliateDomainService.InitUserAffiliates(now.AddDays(-3), now);
            await Task.Delay(3000);
            
            await _conversionDomainService.SyncAffConversions(now.AddDays(-3), now, AffiliateOwnershipType.GDL);
            await Task.Delay(3000);
            
            await _conversionDomainService.SyncAffConversions(now.AddDays(-3), now, AffiliateOwnershipType.HappyDay);
        }
    }
}