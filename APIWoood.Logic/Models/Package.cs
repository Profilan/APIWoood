using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class Package
    {
        public virtual string ARTCODE_PAKKET { get; set; }          // ARTCODE_PAKKET
        public virtual string ARTIKELCODE { get; set; }             // ARTIKELCODE
        public virtual DateTime CREATIONDATE { get; set; }          // CREATIONDATE
        public virtual DateTime DATEFROM { get; set; }              // DATEFROM
        public virtual string NL { get; set; }                      // NL
        public virtual string EN { get; set; }                      // EN
        public virtual string DE { get; set; }                      // DE
        public virtual string FR { get; set; }                      // FR
        public virtual decimal GEWICHT { get; set; }                // GEWICHT
        public virtual decimal VERPAK_DIKTE_MM { get; set; }        // VERPAK_DIKTE_mm
        public virtual decimal VERPAK_LENGTE_MM { get; set; }       // VERPAK_LENGTE_mm
        public virtual decimal VERPAK_BREEDTE_MM { get; set; }      // VERPAK_BREEDTE_mm
        public virtual decimal VOL_M3_VERP { get; set; }            // VOL_M3_VERP
        public virtual decimal VRIJEVOORRAADPAKKET { get; set; }    // VRIJEVOORRAADPAKKET
        public virtual string ASS_CODE_EXCLUSIV { get; set; }       // ASS_CODE_EXCLUSIV
        public virtual string EANCODE_PAKKET { get; set; }          // EANCODE
        public virtual int AANTAL_PAKKETTEN { get; set; }           // AANTAL_PAKKETTEN

        public virtual Product ARTIKEL { get; set; }
    }
}
