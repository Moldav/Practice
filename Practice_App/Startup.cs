using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practice_App.Startup))]
namespace Practice_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }
    }
}
