using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class LogListViewModel
    {
        public IEnumerable<Log> Logs { get; set; }

        public ErrorType ErrorType { get; set; }

        [Display(Name = "User")]
        public int UserId { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}