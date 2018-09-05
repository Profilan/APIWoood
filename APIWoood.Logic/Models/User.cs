using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class User : Entity<int>
    {
        private readonly IPasswordHasher _passwordHasher;

        public virtual string Username { get; set; }
        public virtual string HashedPassword { get; set; }
        public virtual string ApiKey { get; set; }

        public User()
        {

        }

        public User(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public virtual void SetCredentials(string username, string plainTextPassword)
        {
            Username = username;
            SetPassword(plainTextPassword);
        }

        public virtual void SetPassword(string plainTextPassword)
        {
            HashedPassword = _passwordHasher.HashPassword(plainTextPassword);
        }
    }
}
