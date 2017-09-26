using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyHealthyFinances.Startup))]
namespace MyHealthyFinances
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
