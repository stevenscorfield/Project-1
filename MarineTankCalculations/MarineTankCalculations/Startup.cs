using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarineTankCalculations.Startup))]
namespace MarineTankCalculations
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
