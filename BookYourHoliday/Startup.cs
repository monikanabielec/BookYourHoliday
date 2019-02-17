using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookYourHoliday.Startup))]
namespace BookYourHoliday
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
