using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DefaultAuthentication.Startup))]
namespace DefaultAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
