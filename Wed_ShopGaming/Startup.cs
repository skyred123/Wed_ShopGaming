using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wed_ShopGaming.Startup))]
namespace Wed_ShopGaming
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
