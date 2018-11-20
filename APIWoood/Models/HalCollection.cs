using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class HalCollection<T>
    {
        [JsonProperty("_links")]
        public Link Link { get; set; }

        [JsonProperty("_embedded")]
        public IDictionary<string, IList<T>> Embedded { get; set; }

        [JsonProperty("page_count")]
        public int PageCount { get; set; }

        [JsonProperty("page_size")]
        public int PageSize { get; set; }

        [JsonProperty("total_items")]
        public int TotalItems { get; set; }

        [JsonProperty("page")]
        public int CurrentPage { get; set; }

        public HalCollection()
        {
            Embedded = new Dictionary<string, IList<T>>();
        }
    }
}