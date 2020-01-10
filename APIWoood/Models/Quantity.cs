using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class Quantity
    {
        public Year Year { get; set; }
        public Quarter Quarter { get; set; }
        public Month Month { get; set; }

        public Quantity()
        {
            Year = new Year();
            Quarter = new Quarter();
            Month = new Month();
        }
    }
}