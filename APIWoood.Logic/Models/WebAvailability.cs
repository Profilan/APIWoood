using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class WebAvailability
    {
        public virtual WebAvailabilityIdentifier WebAvailabilityIdentifier { get; set; }
        public virtual string TOELICHTING_NL { get; set; }
        public virtual string TOELICHTING_EN { get; set; }
        public virtual string TOELICHTING_DE { get; set; }
        public virtual string TOELICHTING_FR { get; set; }
        public virtual int LEVERWEEK { get; set; }
        public virtual string LEVERWEEK_JJJJWW { get; set; }
        public virtual string OMSCHRIJVING_NL { get; set; }
        public virtual string OMSCHRIJVING_EN { get; set; }
        public virtual string OMSCHRIJVING_DE { get; set; }
        public virtual string OMSCHRIJVING_FR { get; set; }
        public virtual string BRAND { get; set; }
        public virtual string EXCLUSIVE { get; set; }
        public virtual string EANCODE { get; set; }
    }
}
