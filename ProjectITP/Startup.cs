using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectITP.Startup))]
namespace ProjectITP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
