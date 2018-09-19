using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class Url
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Hits { get; set; }
    }
}
