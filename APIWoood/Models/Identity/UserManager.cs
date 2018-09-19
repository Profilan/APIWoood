using APIWoood.Logic.Models;
using Microsoft.AspNet.Identity;

namespace APIWoood.Models.Identity
{
    public class UserManager : UserManager<User, int>
    {
        public UserManager(IUserStore<User, int> store)
            : base(store)
        {
            UserValidator = new UserValidator<User, int>(this);
            PasswordValidator = new PasswordValidator();
            PasswordHasher = new CustomPasswordHasher();
        }
    }
}