using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MtgLife.Website.Startup))]
namespace MtgLife.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
