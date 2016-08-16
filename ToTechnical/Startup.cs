using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToTechnical.Startup))]
namespace ToTechnical
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
