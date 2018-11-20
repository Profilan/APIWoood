using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class UrlViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hits { get; set; }
        public int HitsOld { get; set; }
        public double Duration { get; set; }
        public string LatestVisitDate { get; set; }
        public string LatestVisitDateOld { get; set; }
        public int ErrorCount { get; set; }
    }
}