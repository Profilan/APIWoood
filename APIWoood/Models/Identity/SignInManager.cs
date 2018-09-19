using APIWoood.Logic.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace APIWoood.Models.Identity
{
    public class SignInManager : SignInManager<User, int>
    {
        public SignInManager(UserManager<User, int> userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager) { }

        public void SignOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        
    }
}