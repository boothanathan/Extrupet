using AutoMapper;
using Extrupet.BAL.Interfaces;
using Extrupet.BAL.Models;
using Extrupet.BAL.Utilities;
using Extrupet.DAL.Entity;
using Extrupet.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.BAL.Services
{
    public class UserRoleMasterService : IUserRoleMasterService
    {
        private readonly UserRoleMasterRepository userDAL;
        private readonly Mapper mapper;

        public UserRoleMasterService()
        {
            userDAL = new UserRoleMasterRepository(new ExtrupetEntities());
            mapper = new MapperProfile().Mapper;
        }

        public IEnumerable<UserRoleMasterGet> GetUserRoles()
        {
            var userRoleMaster = userDAL.GetUserRoles()?.ToList();
            var userGets = new List<UserRoleMasterGet>();
            foreach (var um in userRoleMaster)
            {
                userGets.Add(mapper.Map<UserRoleMasterGet>(um));
            }

            return userGets;
        }
    }
}
