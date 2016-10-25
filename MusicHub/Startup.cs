using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicHub.Startup))]
namespace MusicHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
