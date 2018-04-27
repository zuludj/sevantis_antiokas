using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(antiokas.Startup))]
namespace antiokas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
