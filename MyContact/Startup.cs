using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyContact.Startup))]
namespace MyContact
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
