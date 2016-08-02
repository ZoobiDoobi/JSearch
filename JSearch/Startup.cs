using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JSearch.Startup))]
namespace JSearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
