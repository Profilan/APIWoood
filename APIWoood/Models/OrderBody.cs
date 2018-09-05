using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class OrderBody
    {
        public ISet<Order> order { get; set; }

        public OrderBody()
        {
            order = new HashSet<Order>();
        }
    }
}