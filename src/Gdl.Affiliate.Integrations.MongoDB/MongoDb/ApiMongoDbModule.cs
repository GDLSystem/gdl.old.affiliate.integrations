using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.MongoDB;
using Volo.Abp.BackgroundJobs.MongoDB;
using Volo.Abp.BlobStoring.Database.MongoDB;
using Volo.Abp.FeatureManagement.MongoDB;
using Volo.Abp.Identity.MongoDB;
using Volo.Abp.IdentityServer.MongoDB;
using Volo.Abp.LanguageManagement.MongoDB;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.MongoDB;
using Volo.Abp.SettingManagement.MongoDB;
using Volo.Abp.TextTemplateManagement.MongoDB;
using Volo.Abp.Uow;
using Volo.Saas.MongoDB;

namespace Gdl.Affiliate.Integrations.MongoDb
{
    [DependsOn(
        typeof(IntegrationsDomainModule)
    )]
    public class ApiMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            
            context.Services.AddMongoDbContext<ApiMongoDbContext>(options =>
            {
                options.AddDefaultRepositories(true);
            });

            Configure<AbpUnitOfWorkDefaultOptions>(options =>
            {
                options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
            });
        }
    }
}