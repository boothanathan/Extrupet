using Extrupet.BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.BAL.Interfaces
{
    public interface IGradeService
    {
        GradeGet AddOrUpdateGradeMaster(GradeSet grade);
        IEnumerable<GradeGet> GetAllGradeMasters();
        
        GradeTypeGet AddOrUpdateGradeTypeMaster(GradeTypeSet grade);
        IEnumerable<GradeTypeGet> GetAllGradeTypeMasters();
    }
}
