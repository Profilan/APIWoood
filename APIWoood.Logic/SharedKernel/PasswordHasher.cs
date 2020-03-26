using APIWoood.Logic.SharedKernel.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.SharedKernel
{
    public class PasswordHasher : IPasswordHasher
    {
        const string SALT = "%$#HD&^5637*";

        public string HashPassword(string password)
        {
            return string.Join("", SHA1CryptoServiceProvider.Create().ComputeHash(Encoding.UTF8.GetBytes(SALT + password)).Select(x => x.ToString("x2")));
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            throw new NotImplementedException();
        }
    }
}
