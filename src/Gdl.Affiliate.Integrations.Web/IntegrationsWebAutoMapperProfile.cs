using Gdl.Affiliate.Integrations.ShopinessConversions;
using Gdl.Affiliate.Integrations.ShopinessClicks;
using AutoMapper;

namespace Gdl.Affiliate.Integrations.Web
{
    public class IntegrationsWebAutoMapperProfile : Profile
    {
        public IntegrationsWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.

            CreateMap<ShopinessClickDto, ShopinessClickUpdateDto>();

            CreateMap<ShopinessConversionDto, ShopinessConversionUpdateDto>();
        }
    }
}