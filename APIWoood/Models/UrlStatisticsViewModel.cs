using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class UrlStatisticsViewModel
    {
        [Display(Name = "Url")]
        public int Id { get; set; }
        public IEnumerable<Url> Urls { get; set; }

        public int Hits { get; set; }

        public Period Period { get; set; }

        public IList<UserViewModel> Visitors { get; set; }
    }
}