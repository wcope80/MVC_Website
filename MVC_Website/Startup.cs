using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Website.Startup))]
namespace MVC_Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
