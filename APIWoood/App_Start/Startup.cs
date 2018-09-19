using APIWoood;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace APIWoood
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new UserManager(new IdentityStore(SessionFactory.GetNewSession("db2"))));
            app.CreatePerOwinContext<SignInManager>((options, context) => new SignInManager(context.GetUserManager<UserManager>(), context.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider()
            });
        }
    }
}