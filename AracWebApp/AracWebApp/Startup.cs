using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AracWebApp.Startup))]
namespace AracWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
