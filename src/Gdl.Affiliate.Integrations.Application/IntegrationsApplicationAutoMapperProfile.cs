using Gdl.Affiliate.Integrations.ShopinessConversions;
using System;
using Gdl.Affiliate.Integrations.Shared;
using Volo.Abp.AutoMapper;
using Gdl.Affiliate.Integrations.ShopinessClicks;
using AutoMapper;

namespace Gdl.Affiliate.Integrations
{
    public class IntegrationsApplicationAutoMapperProfile : Profile
    {
        public IntegrationsApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<ShopinessClickCreateDto, ShopinessClick>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<ShopinessClickUpdateDto, ShopinessClick>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<ShopinessClick, ShopinessClickDto>();

            CreateMap<ShopinessConversionCreateDto, ShopinessConversion>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<ShopinessConversionUpdateDto, ShopinessConversion>().Ignore(x => x.Id).Ignore(x => x.TenantId);
            CreateMap<ShopinessConversion, ShopinessConversionDto>();
        }
    }
}