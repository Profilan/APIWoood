using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class Pricelist
    {
        public string DEBITEURNR { get; set; }
        public string FAKTUURDEBITEURNR { get; set; }
        public string ARTIKELCODE { get; set; }
        public float SALESPRICE { get; set; }
        public string PRIJSLIJST { get; set; }
        public float KORTING { get; set; }
        public int AANTAL0 { get; set; }
        public float PRIJS0 { get; set; }
        public int AANTAL1 { get; set; }
        public float PRIJS1 { get; set; }
        public int AANTAL2 { get; set; }
        public float PRIJS2 { get; set; }
        public int AANTAL3 { get; set; }
        public float PRIJS3 { get; set; }
        public int AANTAL4 { get; set; }
        public float PRIJS4 { get; set; }
        public int AANTAL5 { get; set; }
        public float PRIJS5 { get; set; }
        public int AANTAL6 { get; set; }
        public float PRIJS6 { get; set; }
        public int AANTAL7 { get; set; }
        public float PRIJS7 { get; set; }
        public int AANTAL8 { get; set; }
        public float PRIJS8 { get; set; }
        public int AANTAL9 { get; set; }
        public float PRIJS9 { get; set; }
        public int AANTAL10 { get; set; }
        public float PRIJS10 { get; set; }
        public string VALCODE { get; set; }
        public float STANDAARD_SALESPRICE { get; set; }
        public string KORTINGTYPE { get; set; }
        public string PRIJSSOORT { get; set; }
    }
}