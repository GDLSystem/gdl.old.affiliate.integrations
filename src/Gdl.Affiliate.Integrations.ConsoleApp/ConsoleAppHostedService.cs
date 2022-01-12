using System;
using System.Threading;
using System.Threading.Tasks;
using Gdl.Affiliate.Integrations.ConsoleApp.Jobs;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace Gdl.Affiliate.Integrations.ConsoleApp
{
    public class ConsoleAppHostedService : IHostedService
    {
        private readonly IAbpApplicationWithExternalServiceProvider _application;
        private readonly IServiceProvider _serviceProvider;
        private readonly MainIntegrationService _mainIntegrationService;
        private readonly SyncShopinessConversionsJob _syncShopinessConversionsJob;
        public ConsoleAppHostedService(
            IAbpApplicationWithExternalServiceProvider application,
            IServiceProvider serviceProvider,
            MainIntegrationService mainIntegrationService, SyncShopinessConversionsJob syncShopinessConversionsJob)
        {
            _application = application;
            _serviceProvider = serviceProvider;
            _mainIntegrationService = mainIntegrationService;
            _syncShopinessConversionsJob = syncShopinessConversionsJob;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _application.Initialize(_serviceProvider);

            _mainIntegrationService.SayHello();
            await _syncShopinessConversionsJob.Execute();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _application.Shutdown();

            return Task.CompletedTask;
        }
    }
}
