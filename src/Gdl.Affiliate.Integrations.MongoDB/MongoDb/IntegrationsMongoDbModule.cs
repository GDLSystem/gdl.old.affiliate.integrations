using Gdl.Affiliate.Integrations.ShopinessConversions;
using Gdl.Affiliate.Integrations.ShopinessClicks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.MongoDB;
using Volo.Abp.BackgroundJobs.MongoDB;
using Volo.Abp.FeatureManagement.MongoDB;
using Volo.Abp.Identity.MongoDB;
using Volo.Abp.IdentityServer.MongoDB;
using Volo.Abp.LanguageManagement.MongoDB;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.MongoDB;
using Volo.Abp.SettingManagement.MongoDB;
using Volo.Abp.TextTemplateManagement.MongoDB;
using Volo.Saas.MongoDB;
using Volo.Abp.BlobStoring.Database.MongoDB;
using Volo.Abp.Uow;

namespace Gdl.Affiliate.Integrations.MongoDB
{
    [DependsOn(
        typeof(IntegrationsDomainModule),
        typeof(AbpPermissionManagementMongoDbModule),
        typeof(AbpSettingManagementMongoDbModule),
        typeof(AbpIdentityProMongoDbModule),
        typeof(AbpIdentityServerMongoDbModule),
        typeof(AbpBackgroundJobsMongoDbModule),
        typeof(AbpAuditLoggingMongoDbModule),
        typeof(AbpFeatureManagementMongoDbModule),
        typeof(LanguageManagementMongoDbModule),
        typeof(SaasMongoDbModule),
        typeof(TextTemplateManagementMongoDbModule),
        typeof(BlobStoringDatabaseMongoDbModule)
    )]
    public class IntegrationsMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<IntegrationsMongoDbContext>(options =>
            {
                options.AddDefaultRepositories();
                options.AddRepository<ShopinessClick, ShopinessClicks.MongoShopinessClickRepository>();

                options.AddRepository<ShopinessConversion, ShopinessConversions.MongoShopinessConversionRepository>();

            });

            Configure<AbpUnitOfWorkDefaultOptions>(options =>
            {
                options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
            });
        }
    }
}