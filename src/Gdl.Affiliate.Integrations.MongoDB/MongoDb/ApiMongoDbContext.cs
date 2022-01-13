using Gdl.Affiliate.Integrations.Posts;
using Gdl.Affiliate.Integrations.UserAffiliates;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Gdl.Affiliate.Integrations.MongoDb
{
    [ConnectionStringName("GdlToolTracking")]
    public class ApiMongoDbContext : AbpMongoDbContext
    {
        public IMongoCollection<UserAffiliate> UserAffiliates => Collection<UserAffiliate>();
        public IMongoCollection<Post> Posts => Collection<Post>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.Entity<UserAffiliate>(b => { b.CollectionName = ApiConsts.DbTablePrefix + "UserAffiliates"; });
            modelBuilder.Entity<Post>(b => { b.CollectionName = ApiConsts.DbTablePrefix + "Posts"; });
        }
    }
}