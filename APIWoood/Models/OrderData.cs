using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class OrderData
    {
        public Header header { get; set; }
        public OrderBody body { get; set; }
    }
}