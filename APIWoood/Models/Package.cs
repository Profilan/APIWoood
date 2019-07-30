using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class Package
    {
        public string ARTCODE_PAKKET { get; set; }          // ARTCODE_PAKKET
        public string ARTIKELCODE { get; set; }             // ARTIKELCODE
        public string CREATIONDATE { get; set; }            // CREATIONDATE
        public string NL { get; set; }                      // NL
        public string EN { get; set; }                      // EN
        public string DE { get; set; }                      // DE
        public string FR { get; set; }                      // FR
        public decimal GEWICHT { get; set; }                // GEWICHT
        public decimal VERPAK_DIKTE_MM { get; set; }        // VERPAK_DIKTE_mm
        public decimal VERPAK_LENGTE_MM { get; set; }       // VERPAK_LENGTE_mm
        public decimal VERPAK_BREEDTE_MM { get; set; }      // VERPAK_BREEDTE_mm
        public decimal VOL_M3_VERP { get; set; }            // VOL_M3_VERP
        public decimal VRIJEVOORRAADPAKKET { get; set; }    // VRIJEVOORRAADPAKKET
        public string ASS_CODE_EXCLUSIV { get; set; }       // ASS_CODE_EXCLUSIV
        [JsonProperty("EANCode_Pakket")]
        public string EANCODE_PAKKET { get; set; }          // EANCODE
        public int AANTAL_PAKKETTEN { get; set; }           // AANTAL_PAKKETTEN
        
    }
}