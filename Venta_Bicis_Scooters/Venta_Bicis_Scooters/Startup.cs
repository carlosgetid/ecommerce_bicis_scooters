using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Venta_Bicis_Scooters.Startup))]
namespace Venta_Bicis_Scooters
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
