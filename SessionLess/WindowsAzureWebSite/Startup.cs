using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WindowsAzureWebSite.Startup))]
namespace WindowsAzureWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
