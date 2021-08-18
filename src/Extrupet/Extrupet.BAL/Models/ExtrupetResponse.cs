using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.BAL.Models
{
    public class ExtrupetResponse
    {
        public bool  Status{ get; set; }
        public string  Message{ get; set; }
        public object ResponseObject { get; set; }
    }
}
