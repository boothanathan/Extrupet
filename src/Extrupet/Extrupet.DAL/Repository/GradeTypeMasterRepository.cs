using Extrupet.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.DAL.Repository
{
    public class GradeTypeMasterRepository : GenericQuery<GradeTypeMaster>
    {
        public GradeTypeMasterRepository(ExtrupetEntities db) : base(db)
        {
        }

        public IEnumerable<GradeTypeMaster> GetAllGradeTypeMasters()
        {
            return base.GetQuery(null);
        }

        public GradeTypeMaster AddOrUpdateGradeTypeMaster(GradeTypeMaster gradeType)
        {
            gradeType = gradeType.GradeTypeId == 0 ? base.Add(gradeType) : base.Update(gradeType);
            return gradeType;
        }
    }
}
