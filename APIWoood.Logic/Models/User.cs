using APIWoood.Logic.SharedKernel.Interfaces;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace APIWoood.Logic.Models
{
    public class User : IUser<int>
    {
        private readonly SharedKernel.Interfaces.IPasswordHasher _passwordHasher;

        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string HashedPassword { get; set; }
        public virtual string ApiKey { get; set; }
        public virtual string Email { get; set; }
        public virtual string Role { get; set; }
        public virtual string AllowedIP { get; set; }

        public virtual ISet<Debtor> Debtors { get; set; }

        public virtual ISet<Url> Urls { get; set; }

        public User()
        {
            Debtors = new HashSet<Debtor>();
            Urls = new HashSet<Url>();
            _passwordHasher = new SharedKernel.PasswordHasher();
        }

        public User(SharedKernel.Interfaces.IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public virtual void SetCredentials(string username, string plainTextPassword)
        {
            UserName = username;
            SetPassword(plainTextPassword);
        }

        public virtual void SetPassword(string plainTextPassword)
        {
            HashedPassword = _passwordHasher.HashPassword(plainTextPassword);
        }
    }
}
