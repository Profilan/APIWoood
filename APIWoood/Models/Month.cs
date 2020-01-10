using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class Month
    {
        public IList<Item> Items { get; set; }

        public Month()
        {
            Items = new List<Item>();
        }
    }
}