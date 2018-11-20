using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class LogViewModel
    {
        [Display(Name = "User")]
        public int UserId { get; set; }
        public IEnumerable<User> Users { get; set; }

        [Display(Name = "Url")]
        public int UrlId { get; set; }
        public IEnumerable<Url> Urls { get; set; }

        public Period Period { get; set; }

        public IEnumerable<Log> Visits { get; set; }

        public IEnumerable<History> VisitsOld { get; set; }
    }
}