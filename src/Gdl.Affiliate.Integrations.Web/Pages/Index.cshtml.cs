using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Gdl.Affiliate.Integrations.Web.Pages
{
    public class IndexModel : IntegrationsPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}