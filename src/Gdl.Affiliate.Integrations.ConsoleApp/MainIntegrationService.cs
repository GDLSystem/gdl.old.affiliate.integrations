using System;
using Gdl.Affiliate.Integrations.Configs;
using Volo.Abp.DependencyInjection;

namespace Gdl.Affiliate.Integrations.ConsoleApp
{
    public class MainIntegrationService : BaseDomainService
    {
        public void SayHello()
        {
            var global = GlobalConfiguration.SlackConfiguration;
            Console.WriteLine("\tHello World!");
        }
    }
}
