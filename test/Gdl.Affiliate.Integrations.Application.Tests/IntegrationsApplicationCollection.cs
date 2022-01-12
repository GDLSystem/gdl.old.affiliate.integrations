using Gdl.Affiliate.Integrations.MongoDB;
using Xunit;

namespace Gdl.Affiliate.Integrations
{
    [CollectionDefinition(IntegrationsTestConsts.CollectionDefinitionName)]
    public class IntegrationsApplicationCollection : IntegrationsMongoDbCollectionFixtureBase
    {

    }
}
