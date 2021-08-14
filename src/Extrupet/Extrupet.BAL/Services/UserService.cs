using Extrupet.BAL.Interfaces;
using Extrupet.BAL.Models;
using Extrupet.DAL.Entity;
using Extrupet.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.BAL.Services
{
    public class UserService : IUserService
    {
        private DAL.Repository.UserRepository userDAL;
        public UserService()
        {
            userDAL = new UserRepository(new DAL.Entity.ExtrupetEntities());
        }

        public IEnumerable<UserGet> GetUsers()
        {
            var userMasters = userDAL.GetUsers()?.ToList();
            var userGets = new List<UserGet>();
            foreach(var um in userMasters)
            {
                userGets.Add(Utilities.Mapper<UserMaster, UserGet>.Map(um, new UserGet()));
            }           

            return userGets;
        }

        public UserGet SaveUsers(UserSet user)
        {
            var userMaster = new UserMaster();           
            userMaster = Utilities.Mapper<UserSet, UserMaster>.Map(user, userMaster);
            userMaster.LastUpdatedOnUTC = DateTime.UtcNow;
            userMaster.LastUpdatedBy = 6;
            userMaster.RoleId = 1;
            userMaster = userDAL.SaveUsers(userMaster);
            var userGet = new UserGet();
            userGet = Utilities.Mapper<UserMaster, UserGet>.Map(userMaster, userGet);
            return userGet;
        }

    }
}
