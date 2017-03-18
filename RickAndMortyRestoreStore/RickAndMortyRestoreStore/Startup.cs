using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RickAndMortyRestoreStore.Startup))]
namespace RickAndMortyRestoreStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
