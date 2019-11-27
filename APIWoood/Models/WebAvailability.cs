using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class WebAvailability
    {
        public virtual string FAKDEBNR { get; set; }
        public virtual string ITEMCODE { get; set; }
        public virtual string TOELICHTING_NL { get; set; }
        public virtual string TOELICHTING_EN { get; set; }
        public virtual string TOELICHTING_DE { get; set; }
        public virtual string TOELICHTING_FR { get; set; }
        public virtual string LEVERWEEK { get; set; }
        public virtual string LEVERWEEK_JJJJWW { get; set; }
        public virtual string OMSCHRIJVING_NL { get; set; }
        public virtual string OMSCHRIJVING_EN { get; set; }
        public virtual string OMSCHRIJVING_DE { get; set; }
        public virtual string OMSCHRIJVING_FR { get; set; }
        public virtual string BRAND { get; set; }
        public virtual string EXCLUSIVE { get; set; }
        [JsonProperty("EANCode")]
        public virtual string EANCODE { get; set; }
        public string SYSCREATED { get; set; }
        public string SYSMODIFIED { get; set; }
    }
}