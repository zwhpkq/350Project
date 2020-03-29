using Microsoft.Owin;
using Owin;


[assembly:OwinStartupAttribute(typeof(_350Project.Startup))]
namespace _350Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app) {
            app.MapSignalR();
        }

    }
}