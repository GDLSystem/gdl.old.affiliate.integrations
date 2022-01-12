using System.Threading.Tasks;

namespace Gdl.Affiliate.Integrations.Data
{
    public interface IIntegrationsDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}