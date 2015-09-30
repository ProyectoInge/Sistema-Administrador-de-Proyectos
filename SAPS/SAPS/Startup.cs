using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SAPS.Startup))]
namespace SAPS
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
