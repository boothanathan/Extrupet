using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.BAL.Models
{
    public class GradeTypeBase
    {
        public byte GradeTypeId { get; set; }
        public string GradeType { get; set; }
    }

    public class GradeTypeSet : GradeTypeBase
    {
    }

    public class GradeTypeGet : GradeTypeBase
    {
    }

   
}
 