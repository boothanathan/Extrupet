using Extrupet.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.DAL.Repository
{
    public class GradeMasterRepository : GenericQuery<GradeMaster>
    {
        public GradeMasterRepository(ExtrupetEntities db) : base(db)
        {
        }

        public IEnumerable<GradeMaster> GetAllGradeMasters()
        {
            return base.GetQuery(null);
        }

        public GradeMaster AddOrUpdateGradeMaster(GradeMaster grade)
        {            
            grade = grade.GradeId == 0 ? base.Add(grade) : base.Update(grade);
            return grade;
        }
    }
}
