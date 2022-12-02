using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LastMVCWithAuth.Startup))]
namespace LastMVCWithAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
