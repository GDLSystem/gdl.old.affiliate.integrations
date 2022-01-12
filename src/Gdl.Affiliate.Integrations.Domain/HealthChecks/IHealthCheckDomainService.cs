using System.Threading.Tasks;
using FacebookCommunityAnalytics.Api.HealthChecks;
using Gdl.Affiliate.Integrations.HealthChecks.Models;
using Volo.Abp.Domain.Services;

namespace Gdl.Affiliate.Integrations.HealthChecks
{
    public interface IHealthCheckDomainService : IDomainService
    {
        Task SendNotificationToSlack(SlackMessage input);
    }

    public class HealthCheckDomainService : BaseDomainService, IHealthCheckDomainService
    {
        public async Task SendNotificationToSlack(SlackMessage input)
        {
            var slackClient = new SlackMessageClient(GlobalConfiguration.SlackConfiguration.WebhookUrl);
            await slackClient.SendAsync(input);
        }
    }
}