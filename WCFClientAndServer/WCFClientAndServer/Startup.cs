using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WCFClientAndServer.Startup))]
namespace WCFClientAndServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
