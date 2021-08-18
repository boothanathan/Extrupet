using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.BAL.Models
{
    public class GradeBase
    {
        public byte GradeId { get; set; }
        public string GradeName { get; set; }
        public bool IsActive { get; set; }
       
    }
    public class GradeSet : GradeBase
    {

    }

    public class GradeGet : GradeBase
    {
        public System.DateTime LastUpdatedOnUTC { get; set; }
        public System.Guid LastUpdatedBy { get; set; }
    }
    

}
