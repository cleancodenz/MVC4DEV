using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SessionLess.Startup))]
namespace SessionLess
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
