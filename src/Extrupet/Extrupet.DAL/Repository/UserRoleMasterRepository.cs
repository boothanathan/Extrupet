using Extrupet.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.DAL.Repository
{
    public class UserRoleMasterRepository : GenericQuery<UserRoleMaster>
    {
        private ExtrupetEntities _context;
        public UserRoleMasterRepository(ExtrupetEntities context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<UserRoleMaster> GetUserRoles()
        {
            return base.GetQuery(null);
        }

    }
}
