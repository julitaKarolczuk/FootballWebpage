using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SBDProject.Startup))]
namespace SBDProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
