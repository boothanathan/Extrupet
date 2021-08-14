using Extrupet.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.DAL.Repository
{
    public class UserRepository : GenericQuery<UserMaster>
    {
        private ExtrupetEntities _context;
        public UserRepository(ExtrupetEntities context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<UserMaster> GetUsers()
        {
            return base.GetQuery(x => x.UserId > 0);
        }

        public UserMaster SaveUsers(UserMaster userMaster)
        {
            return base.Add(userMaster);            
        }
    }
}
