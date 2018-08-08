using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tecdisa.OS.Site.UI.Startup))]
namespace Tecdisa.OS.Site.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
