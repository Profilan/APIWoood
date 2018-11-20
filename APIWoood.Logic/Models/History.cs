using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class History
    {
        public virtual HistoryIdentifier HistoryIdentifier { get; set; }
        public virtual int StatusCode { get; set; }
    }
}
