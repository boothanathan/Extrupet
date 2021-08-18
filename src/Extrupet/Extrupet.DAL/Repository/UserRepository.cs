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

        public UserMaster GetUser(Guid userID)
        {
            var user =  base.GetQuery(x=>x.UserId == userID).FirstOrDefault();   
            return user;
        } 
        
        public UserMaster GetUserFromLoginId(string loginId)
        {
            var user =  base.GetQuery(x=>x.EmailId == loginId).FirstOrDefault();
            if(user == null)
            {
                user = base.GetQuery(x=>x.EmployeeId== loginId).FirstOrDefault();
            }

            return user;
        } 
    }
}
