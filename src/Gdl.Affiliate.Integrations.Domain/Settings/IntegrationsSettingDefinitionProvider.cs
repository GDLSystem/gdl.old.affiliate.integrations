using Volo.Abp.Settings;

namespace Gdl.Affiliate.Integrations.Settings
{
    public class IntegrationsSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(IntegrationsSettings.MySetting1));
        }
    }
}
