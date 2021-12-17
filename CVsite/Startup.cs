using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CVsite.Startup))]
namespace CVsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
