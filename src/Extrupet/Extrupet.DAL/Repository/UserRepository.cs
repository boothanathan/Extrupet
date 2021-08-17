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

        public IEnumerable<UserMaster> GetAllUsers()
        {
            return base.GetQuery(null);
        }
        
        public UserMaster CreateUser(UserMaster userMaster)
        {
            userMaster.UserId= Guid.NewGuid();
            userMaster.LastUpdatedOnUTC = DateTime.UtcNow;
            return base.Add(userMaster);
        } 

        public UserMaster UpdateUser(UserMaster userMaster)
        {            
            userMaster.LastUpdatedOnUTC = DateTime.UtcNow;
            return base.Update(userMaster);
        } 

        public UserMaster GetUser(string userId)
        {
            var user =  base.GetQuery(x=>x.EmailId == userId).FirstOrDefault();
            if(user == null)
            {
                base.GetQuery(x=>x.EmployeeId== userId).FirstOrDefault();
            }

            return user;
        } 
        
        
        

        public UserMaster SaveUsers(UserMaster userMaster)
        {
            return base.Add(userMaster);            
        }
    }
}
