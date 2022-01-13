using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Gdl.Affiliate.Integrations.Core.Const;
using Gdl.Affiliate.Integrations.Core.Enums;
using Gdl.Affiliate.Integrations.Core.Extensions;
using Gdl.Affiliate.Integrations.Integrations.Shopiness;
using Gdl.Affiliate.Integrations.Posts;
using Gdl.Affiliate.Integrations.Shopiness.Models;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Gdl.Affiliate.Integrations.UserAffiliates
{
    public interface IUserAffiliateDomainService : IDomainService
    {
        Task InitUserAffiliates(DateTime? fromDateTime, DateTime? toDateTime);
    }

    public class UserAffiliateDomainService : BaseDomainService, IUserAffiliateDomainService
    {
        private readonly IRepository<Post,Guid> _postRepository;
        private readonly IRepository<UserAffiliate, Guid> _userAffiliateRepository;
        public UserAffiliateDomainService(
            IShopinessDomainService shopinessDomainService, IRepository<Post, Guid> postRepository, IRepository<UserAffiliate, Guid> userAffiliateRepository)
        {
            _postRepository = postRepository;
            _userAffiliateRepository = userAffiliateRepository;
        }

        #region Init

        public async Task InitUserAffiliates(DateTime? fromDateTime, DateTime? toDateTime)
        {
            var postNavs = await _postRepository
                .GetListAsync(p=>p.SubmissionDateTime >= fromDateTime 
                                 && p.SubmissionDateTime <= toDateTime 
                                 && p.PostContentType == PostContentType.Affiliate);
            if (postNavs.IsNullOrEmpty()) return;
            postNavs = postNavs.Where(p => p.Shortlinks.IsNotNullOrEmpty() && p.AppUserId.HasValue).ToList();

            Debug.WriteLine($"===========================================InitUserAffiliates for {postNavs.Count} posts");
            
            // 1. get the SHORTLINK OWNER
            ConcurrentBag<UserAffiliateModel> affiliateModels = new();

            Parallel.ForEach
            (
                postNavs,
                postNav =>
                {
                    if (postNav.Shortlinks.IsNotNullOrEmpty())
                    {
                        var shortUrls = postNav.Shortlinks;
                        foreach (var shortUrl in shortUrls)
                        {
                            var item = new UserAffiliateModel
                            {
                                Shortlink = shortUrl,
                                AppUserId = postNav.AppUserId.Value,
                                CreatedAt = postNav.SubmissionDateTime ?? DateTime.UtcNow,
                                GroupId = postNav.GroupId
                            };

                            if (affiliateModels.All(_ => _.Shortlink != shortUrl))
                            {
                                affiliateModels.Add(item); 
                                Debug.WriteLine($"===========================================InitUserAffiliates - building shortlink model: {shortUrl}");
                            }
                        }
                    }
                }
            );
            Debug.WriteLine($"===========================================InitUserAffiliates - FOUND for {affiliateModels.Count} shortlinks");

            var updateAffiliates = new List<UserAffiliate>();
            var userAffiliateModels = Enumerable.DistinctBy(affiliateModels, _ => _.Shortlink.Trim()).ToList();

            var newUserAffs = new List<UserAffiliate>();

            // 2. map the OWNER (APPUSER) to current affiliates
            foreach (var batch in userAffiliateModels.Partition(1000))
            {
                var currentPartition = batch.ToList();
                var shortUrls = currentPartition.Select(_ => _.Shortlink.Trim()).ToList();

                var existingAffiliates = await _userAffiliateRepository.GetListAsync(u => !u.IsDeleted && shortUrls.Contains(u.AffiliateUrl));
                foreach (var userAff in currentPartition)
                {
                    var existing = existingAffiliates.FirstOrDefault(_ => _.AffiliateUrl == userAff.Shortlink.Trim());
                    if (existing == null)
                    {
                        var newAff = new UserAffiliate
                        {
                            AppUserId = userAff.AppUserId,
                            MarketplaceType = MarketplaceType.Shopee,
                            AffiliateUrl = userAff.Shortlink,
                            CreatedAt = userAff.CreatedAt,
                            GroupId = userAff.GroupId
                        };
                        newUserAffs.Add(InitUserAffiliateCreation(newAff));

                        Debug.WriteLine($"===========================================InitUserAffiliates - NEW USER AFFILIATE: {userAff.Shortlink}");
                    }
                    else
                    {
                        existing.AppUserId = userAff.AppUserId;
                        existing.GroupId = userAff.GroupId;
                        updateAffiliates.Add(existing);
                        Debug.WriteLine($"===========================================InitUserAffiliates - UPDATE USER AFFILIATE: {existing.AffiliateUrl}");
                    }
                }
            }
 
            if (updateAffiliates.IsNotNullOrEmpty())
            {
                foreach (var batch in updateAffiliates.Partition(100)) { await _userAffiliateRepository.UpdateManyAsync(batch); }
            }

            if (newUserAffs.IsNotNullOrEmpty())
            {
                foreach (var batch in newUserAffs.Partition(100)) { await _userAffiliateRepository.InsertManyAsync(batch); }
            }
        }

        public UserAffiliate InitUserAffiliateCreation(UserAffiliate input)
        {
            if (input.PartnerId == Guid.Empty) input.PartnerId = null;
            if (input.CampaignId == Guid.Empty) input.CampaignId = null;
            if (input.GroupId == Guid.Empty) input.GroupId = null;

            if (input.AffiliateUrl.Contains(GlobalConsts.BaseAffiliateDomain) || input.AffiliateUrl.Contains(GlobalConsts.GDLDomain)) { input.AffiliateOwnershipType = AffiliateOwnershipType.GDL; }
            else if (input.AffiliateUrl.Contains(GlobalConsts.HPDDomain)) { input.AffiliateOwnershipType = AffiliateOwnershipType.HappyDay; }
            else if (input.AffiliateUrl.Contains(GlobalConsts.YANDomain)) { input.AffiliateOwnershipType = AffiliateOwnershipType.YAN; }
            else { input.AffiliateOwnershipType = AffiliateOwnershipType.Unknown; }

            return input;
        }

        #endregion

        public class UserAffiliateModel
        {
            public string Shortlink { get; set; }
            public DateTime? CreatedAt { get; set; }
            public Guid AppUserId { get; set; }
            public Guid? GroupId { get; set; }
        }
    }
}