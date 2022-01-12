using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Gdl.Affiliate.Integrations.Data
{
    /* This is used if database provider does't define
     * IIntegrationsDbSchemaMigrator implementation.
     */
    public class NullIntegrationsDbSchemaMigrator : IIntegrationsDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}