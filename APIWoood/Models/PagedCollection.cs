using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class PagedCollection<T>
    {
        public IList<T> _embedded { get; set; }
        public int page_count { get; set; }
        public int page_size { get; set; }
        public int total_items { get; set; }
        public int page { get; set; }
    }
}