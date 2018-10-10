using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using System.Collections.Generic;

namespace APIWoood.Models
{
    public class DashboardViewModel
    {
        public string TopFiveUrlsData { get; set; }

        public string TopFiveUsersData { get; set; }

        public string UrlUsageData { get; set; }

        public IEnumerable<UrlViewModel> LogErrors { get; set; }

        public Period Period { get; set; }
    }
}