using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class Product
    {
        public virtual string ARTIKELCODE { get; set; }                     // ARTIKELCODE
        public virtual DateTime CREATIONDATE { get; set; }                  // CREATIONDATE
        public virtual DateTime DATEFROM { get; set; }                  // CREATIONDATE
        public virtual string NL { get; set; }                              // NL
        public virtual string EN { get; set; }                              // EN
        public virtual string DE { get; set; }                              // DE
        public virtual string FR { get; set; }                              // FR
        public virtual string COLOR_FINISH { get; set; }                    // COLOR_FINISH
        public virtual string MATERIAL { get; set; }                        // MATERIAL
        public virtual string BRAND { get; set; }                           // BRAND
        public virtual string ASSORTMENT { get; set; }                      // ASSORTMENT
        public virtual string PRODUCTGROUP_CODE { get; set; }               // PRODUCTGROUP_CODE
        public virtual string PRODUCTGROUP { get; set; }                    // PRODUCTGROUP
        public virtual string DEFAULT_SUBPRODUCTGROUP_CODE { get; set; }    // DEFAULT_SUBPRODUCTGROUP_CODE
        public virtual string DEFAULT_SUBPRODUCTGROUP_NAME { get; set; }    // DEFAULT_PRODUCTGROUP_NAME
        public virtual string RANGE { get; set; }                           // RANGE
        public virtual string STATUS { get; set; }                          // STATUS
        public virtual string EXCLUSIV { get; set; }                        // EXCLUSIV
        public virtual decimal VERKOOPPRIJS { get; set; }                   // VERKOOPPRIJS
        public virtual string VERKOOPEENHEID { get; set; }                  // VERKOOPEENHEID
        public virtual int AANTAL_PAKKETTEN { get; set; }                   // AANTAL_PAKKETTEN
        public virtual string AFMETING_ARTIKEL_HXBXD { get; set; }          // AFMETING_ARTIKEL_HXBXD
        public virtual string EANCODE { get; set; }                         // EANCODE
        public virtual string EN_LONG_DESC { get; set; }                    // EN_LONG_DESC
        public virtual string NL_LONG_DESC { get; set; }                    // NL_LONG_DESC
        public virtual string DE_LONG_DESC { get; set; }                    // DE_LONG_DESC
        public virtual string FR_LONG_DESC { get; set; }                    // FR_LONG_DESC
        public virtual int AANTAL_VERP { get; set; }                        // AANTAL_VERP
        public virtual string SOURCE { get; set; }                          // SOURCE
        public virtual string MRP_RUN { get; set; }                         // MRP_RUN
        public virtual decimal CONSUMENTENPRIJS { get; set; }               // CONSUMENTENPRIJS
        public virtual decimal CONSUMENTENPRIJS_VAN { get; set; }           // CONSUMENTENPRIJS_VAN
        public virtual decimal ISE_CONSUMENTENPRIJS { get; set; }           // ISE_CONSUMENTENPRIJS
        public virtual decimal ISE_CONSUMENTENPRIJS_VAN { get; set; }       // ISE_CONSUMENTENPRIJS_VAN
        public virtual decimal GEWICHT { get; set; }                        // GEWICHT
        public virtual bool NEW_ARRIVAL { get; set; }                       // NEW_ARRIVAL
        public virtual decimal VERPAK_DIKTE_MM { get; set; }                // VERPAK_DIKTE_mm
        public virtual decimal VERPAK_LENGTE_MM { get; set; }               // VERPAK_LENGTE_mm
        public virtual decimal VERPAK_BREEDTE_MM { get; set; }              // VERPAK_BREEDTE_mm
        public virtual decimal VOL_M3_VERP { get; set; }                    // VOL_M3_VERP
        public virtual decimal VRIJEVOORRAAD { get; set; }                  // VrijeVoorraad
        public virtual string ASS_CODE_EXCLUSIV { get; set; }               // ASS_CODE_EXCLUSIV
        public virtual string ATP { get; set; }                             // ATP
        public virtual string DFF_SHIPMENT { get; set; }                    // DFF_SHIPMENT
        public virtual bool FSC { get; set; }                               // FSC
        public virtual string COUNTRY_OF_ORIGIN { get; set; }               // COUNTRY_OF_ORIGIN
        public virtual string INTRASTAT_CODE { get; set; }                  // INTRASTAT_CODE
        public virtual bool ASSEMBLY_REQUIRED { get; set; }                 // ASSEMBLY_REQUIRED
        public virtual decimal WEB_VAN_PRIJS_NL { get; set; }               // WEB_VAN_PRIJS_NL
        public virtual decimal WEB_VAN_PRIJS_ISE { get; set; }              // WEB_VAN_PRIJS_ISE
        public virtual string AVAILABILITY_WEEK { get; set; }               // AVAILABILITY_WEEK

        public virtual ISet<Package> PAKKETTEN { get; set; }

        public Product()
        {
            PAKKETTEN = new HashSet<Package>();
        }
    }
}
