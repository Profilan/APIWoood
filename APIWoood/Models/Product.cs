using APIWoood.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class Product
    {
        public string ARTIKELCODE { get; set; }                     // ARTIKELCODE
        public string CREATIONDATE { get; set; }                    // CREATIONDATE
        public string NL { get; set; }                              // NL
        public string EN { get; set; }                              // EN
        public string DE { get; set; }                              // DE
        public string FR { get; set; }                              // FR
        public string COLOR_FINISH { get; set; }                    // COLOR_FINISH
        public string MATERIAL { get; set; }                        // MATERIAL
        public string BRAND { get; set; }                           // BRAND
        public string ASSORTMENT { get; set; }                      // ASSORTMENT
        public string PRODUCTGROUP_CODE { get; set; }               // PRODUCTGROUP_CODE
        public string PRODUCTGROUP { get; set; }                    // PRODUCTGROUP
        public string DEFAULT_SUBPRODUCTGROUP_CODE { get; set; }    // DEFAULT_SUBPRODUCTGROUP_CODE
        public string DEFAULT_SUBPRODUCTGROUP_NAME { get; set; }    // DEFAULT_PRODUCTGROUP_NAME
        public string RANGE { get; set; }                           // RANGE
        public string STATUS { get; set; }                          // STATUS
        public string EXCLUSIV { get; set; }                        // EXCLUSIV
        public decimal VERKOOPPRIJS { get; set; }                   // VERKOOPPRIJS
        public string VERKOOPEENHEID { get; set; }                  // VERKOOPEENHEID
        public int AANTAL_PAKKETTEN { get; set; }                   // AANTAL_PAKKETTEN
        public string AFMETING_ARTIKEL_HXBXD { get; set; }          // AFMETING_ARTIKEL_HXBXD
        public string EANCODE { get; set; }                         // EANCODE
        public string EN_LONG_DESC { get; set; }                    // EN_LONG_DESC
        public string NL_LONG_DESC { get; set; }                    // NL_LONG_DESC
        public string DE_LONG_DESC { get; set; }                    // DE_LONG_DESC
        public string FR_LONG_DESC { get; set; }                    // FR_LONG_DESC
        public int AANTAL_VERP { get; set; }                        // AANTAL_VERP
        public string SOURCE { get; set; }                          // SOURCE
        public string MRP_RUN { get; set; }                         // MRP_RUN
        public decimal CONSUMENTENPRIJS { get; set; }               // CONSUMENTENPRIJS
        public decimal CONSUMENTENPRIJS_VAN { get; set; }           // CONSUMENTENPRIJS_VAN
        public decimal ISE_CONSUMENTENPRIJS { get; set; }           // ISE_CONSUMENTENPRIJS
        public decimal ISE_CONSUMENTENPRIJS_VAN { get; set; }       // ISE_CONSUMENTENPRIJS_VAN
        public decimal GEWICHT { get; set; }                        // GEWICHT
        public bool NEW_ARRIVAL { get; set; }                       // NEW_ARRIVAL
        public decimal VERPAK_DIKTE_MM { get; set; }                // VERPAK_DIKTE_mm
        public decimal VERPAK_LENGTE_MM { get; set; }               // VERPAK_LENGTE_mm
        public decimal VERPAK_BREEDTE_MM { get; set; }              // VERPAK_BREEDTE_mm
        public decimal VOL_M3_VERP { get; set; }                    // VOL_M3_VERP
        public decimal VRIJEVOORRAAD { get; set; }                  // VrijeVoorraad
        public string ASS_CODE_EXCLUSIV { get; set; }               // ASS_CODE_EXCLUSIV
        public string ATP { get; set; }                             // ATP
        public string DFF_SHIPMENT { get; set; }                    // DFF_SHIPMENT
        public bool FSC { get; set; }                               // FSC
        public string COUNTRY_OF_ORIGIN { get; set; }               // COUNTRY_OF_ORIGIN
        public string INTRASTAT_CODE { get; set; }                  // INTRASTAT_CODE
        public bool ASSEMBLY_REQUIRED { get; set; }                 // ASSEMBLY_REQUIRED
        public decimal WEB_VAN_PRIJS_NL { get; set; }               // WEB_VAN_PRIJS_NL
        public decimal WEB_VAN_PRIJS_ISE { get; set; }              // WEB_VAN_PRIJS_ISE
        public string AVAILABILITY_WEEK { get; set; }               // AVAILABILITY_WEEK

        public IList<Package> PAKKETTEN { get; set; }

        public Product()
        {
            PAKKETTEN = new List<Package>();
        }
    }
}