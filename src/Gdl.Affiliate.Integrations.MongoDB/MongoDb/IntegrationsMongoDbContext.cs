using Gdl.Affiliate.Integrations.ShopinessConversions;
using Gdl.Affiliate.Integrations.ShopinessClicks;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Gdl.Affiliate.Integrations.MongoDB
{
    [ConnectionStringName("Default")]
    public class IntegrationsMongoDbContext : AbpMongoDbContext
    {
        public IMongoCollection<ShopinessConversion> ShopinessConversions => Collection<ShopinessConversion>();
        public IMongoCollection<ShopinessClick> ShopinessClicks => Collection<ShopinessClick>();

        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            //builder.Entity<YourEntity>(b =>
            //{
            //    //...
            //});

            modelBuilder.Entity<ShopinessClick>(b => { b.CollectionName = IntegrationsConsts.DbTablePrefix + "ShopinessClicks"; });

            modelBuilder.Entity<ShopinessConversion>(b => { b.CollectionName = IntegrationsConsts.DbTablePrefix + "ShopinessConversions"; });
        }
    }
    
    
}