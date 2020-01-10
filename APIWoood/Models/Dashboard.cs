using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class Dashboard
    {
        public Quantity Quantity { get; set; }
        public Sales Sales { get; set; }

        public Dashboard()
        {
            Quantity = new Quantity();
            Sales = new Sales();
        }
    }
}