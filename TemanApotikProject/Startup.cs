using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TemanApotikProject.Startup))]
namespace TemanApotikProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
