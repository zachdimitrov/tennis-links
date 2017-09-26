using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TennisLinks.Web.Startup))]
namespace TennisLinks.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
