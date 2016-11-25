using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlowOut.Startup))]
namespace BlowOut
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
