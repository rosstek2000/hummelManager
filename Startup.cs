using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hummelManager.Startup))]
namespace hummelManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
