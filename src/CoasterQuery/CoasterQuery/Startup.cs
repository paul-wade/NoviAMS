using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoasterQuery.Startup))]
namespace CoasterQuery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
