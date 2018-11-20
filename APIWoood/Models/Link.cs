using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class LinkHref
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class Link
    {
        [JsonProperty("self")]
        public LinkHref Self { get; set; }

        [JsonProperty("first", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public LinkHref First { get; set; }

        [JsonProperty("prev", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public LinkHref Prev { get; set; }

        [JsonProperty("next", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public LinkHref Next { get; set; }

        [JsonProperty("last", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public LinkHref Last { get; set; }
    }
}