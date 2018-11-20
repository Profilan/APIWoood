
using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models.Identity;
using APIWoood.Results;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace APIWoood.Filters
{
    public class IdentityBasicAuthenticationAttribute : BasicAuthenticationAttribute
    {
        protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            UserManager userManager = CreateUserManager();

            cancellationToken.ThrowIfCancellationRequested(); // Unfortunately, UserManager doesn't support CancellationTokens.
            User user = await userManager.FindAsync(userName, password);

            if (user == null)
            {
                // No user with userName/password exists.
                context.ErrorResult = new AuthenticationFailureResult("Invalid credentials", request);
                return null;
            }

            // Create a ClaimsIdentity with all the claims for this user.
            cancellationToken.ThrowIfCancellationRequested(); // Unfortunately, IClaimsIdenityFactory doesn't support CancellationTokens.
            ClaimsIdentity identity = await userManager.ClaimsIdentityFactory.CreateAsync(userManager, user, "Basic");
            return new ClaimsPrincipal(identity);
        }

        private static UserManager CreateUserManager()
        {
            return new UserManager(new IdentityStore(SessionFactory.GetNewSession("db2")));
        }
    }
}