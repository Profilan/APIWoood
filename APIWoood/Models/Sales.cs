using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class Sales
    {
        public Year Year { get; set; }
        public Quarter Quarter { get; set; }
        public Month Month { get; set; }

        public Sales()
        {
            Year = new Year();
            Quarter = new Quarter();
            Month = new Month();
        }
    }
}