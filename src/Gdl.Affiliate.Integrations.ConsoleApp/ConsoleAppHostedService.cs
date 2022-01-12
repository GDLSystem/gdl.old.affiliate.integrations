using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace Gdl.Affiliate.Integrations.ConsoleApp
{
    public class ConsoleAppHostedService : IHostedService
    {
        private readonly IAbpApplicationWithExternalServiceProvider _application;
        private readonly IServiceProvider _serviceProvider;
        private readonly MainIntegrationService _mainIntegrationService;

        public ConsoleAppHostedService(
            IAbpApplicationWithExternalServiceProvider application,
            IServiceProvider serviceProvider,
            MainIntegrationService mainIntegrationService)
        {
            _application = application;
            _serviceProvider = serviceProvider;
            _mainIntegrationService = mainIntegrationService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _application.Initialize(_serviceProvider);

            _mainIntegrationService.SayHello();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _application.Shutdown();

            return Task.CompletedTask;
        }
    }
}
