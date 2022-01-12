using Gdl.Affiliate.Integrations.Configs;
using Volo.Abp.Domain.Services;
using Volo.Abp.ObjectMapping;

namespace Gdl.Affiliate.Integrations
{
    public abstract class BaseDomainService : DomainService
    {
        public GlobalConfiguration GlobalConfiguration { get; set; }
        public IObjectMapper ObjectMapper { get; set; }

    }
}