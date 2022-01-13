using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookCommunityAnalytics.Api.Core.Const;
using Gdl.Affiliate.Integrations.HealthChecks;
using Gdl.Affiliate.Integrations.HealthChecks.Models;

namespace Gdl.Affiliate.Integrations.ConsoleApp.Jobs
{
    public interface IIntegrationJob
    {
        Task Execute();
    }

    public abstract class BackgroundJobBase : BaseDomainService, IIntegrationJob
    {
        public IHealthCheckDomainService HealthCheckDomainService { get; set; }

        public virtual async Task Execute()
        {
            var msg = new SlackMessage
            {
                Text = "Trạng thái hoạt động của jobs",
                Channel = "general",
                Username = "SlackBotMessages",
                Attachments = new List<SlackAttachment>()
            };
            try
            {
                await DoExecute();

                var textAttachment = $"[GLD.Affiliate.Integrations] Job [{this.GetType().Name}] successful at [{DateTime.UtcNow:dd-MM-yyyy HH:mm}] UTC";
               
                msg.Attachments.Add
                (
                    new SlackAttachment
                    {
                        Text = textAttachment,
                        Color = "good",
                        Fields = new List<SlackField> { new() { Title = Emoji.HeavyCheckMark + " Success" } }
                    }
                );
            }
            catch (Exception e)
            {
                var textAttachment = $"[GLD.Affiliate.Integrations] Job [{this.GetType().Name}] failed at [{DateTime.UtcNow:dd-MM-yyyy HH:mm}] UTC";
                
                textAttachment = textAttachment + "\n " + e.Message;
                textAttachment = textAttachment + "\n " + e.StackTrace;

                msg.Attachments.Add
                (
                    new SlackAttachment
                    {
                        Text = textAttachment,
                        Color = "danger",
                        Fields = new List<SlackField> { new() { Title = Emoji.HeavyCheckMark + " Failed" } }
                    }
                );
            }

            await HealthCheckDomainService.SendNotificationToSlack(msg);
        }

        protected abstract Task DoExecute();
    }
}