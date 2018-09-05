using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class SellingPoint
    {
        public string ARTIKELCODE { get; set; }
        public string FACTUURDEBITEURNR { get; set; }
        public string FACTUURDEBITEURNAAM { get; set; }
        public string FACTUURDEBITEUR_NAAM_ALIAS { get; set; }
        public string FACTUURDEBITEURWEB { get; set; }
        public string FACTUURDEBITEUR_WEB_ALIAS { get; set; }
        public string FACTUURDEBITEURLAND { get; set; }
    }
}