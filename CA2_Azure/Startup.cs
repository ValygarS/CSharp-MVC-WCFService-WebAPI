using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CA2_Azure.Startup))]
namespace CA2_Azure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
