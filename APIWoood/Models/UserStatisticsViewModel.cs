using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class UserStatisticsViewModel
    {
        [Display(Name = "User")]
        public int Id { get; set; }
        public IEnumerable<User> Users { get; set; }

        public Period Period { get; set; }

        public IList<UrlViewModel> VisitedUrls { get; set; }
    }
}