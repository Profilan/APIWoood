using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class Quarter
    {
        public IList<Item> Items { get; set; }

        public Quarter()
        {
            Items = new List<Item>();
        }
    }
}