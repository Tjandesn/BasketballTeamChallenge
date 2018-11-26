using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Basketball_ASP.Startup))]
namespace Basketball_ASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
