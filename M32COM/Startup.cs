using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(M32COM.Startup))]
namespace M32COM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
