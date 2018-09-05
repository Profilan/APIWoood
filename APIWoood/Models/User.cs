using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class User
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string ApiKey { get; set; }
    }
}