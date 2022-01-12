namespace Gdl.Affiliate.Integrations.Configs
{
    public class GlobalConfiguration
    {
        public AffiliateConfiguration AffiliateConfiguration { get; set; }
        public SlackConfiguration SlackConfiguration { get; set; }
    }

    public class SlackConfiguration
    {
        public string WebhookUrl { get; set; }
    }
    public class AffiliateConfiguration
    {
        public int InitDayCount { get; set; }
    }
}
