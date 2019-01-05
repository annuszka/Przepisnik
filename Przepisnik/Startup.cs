using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Przepisnik.Startup))]
namespace Przepisnik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
