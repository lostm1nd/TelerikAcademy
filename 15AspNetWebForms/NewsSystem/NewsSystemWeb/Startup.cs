using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsSystemWeb.Startup))]
namespace NewsSystemWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
