using System;
using Volo.Abp.DependencyInjection;

namespace Gdl.Affiliate.Integrations.ConsoleApp
{
    public class MainIntegrationService : ITransientDependency
    {
        public void SayHello()
        {
            Console.WriteLine("\tHello World!");
        }
    }
}
