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
    public class UserService : IUserService
    {
        private readonly UserRepository userDAL;
        private readonly Mapper mapper;

        public UserService()
        {
            userDAL = new UserRepository(new ExtrupetEntities());
            mapper = new MapperProfile().Mapper;
        }

        public UserGet CreateUser(UserSet userSet)
        {
            var user = userDAL.CreateUser(mapper.Map<UserMaster>(userSet));
            return mapper.Map<UserGet>(user);
        }

        public IEnumerable<UserGet> GetAllUsers()
        {
            var userRoleMaster = userDAL.GetAllUsers().ToList();
            var userGets = new List<UserGet>();
            foreach (var um in userRoleMaster)
            {
                userGets.Add(mapper.Map<UserGet>(um));
            }

            return userGets;
        }
        
        public UserGet Login(UserLogin userLogin)
        {
            var user = userDAL.GetUser(userLogin.LoginId);
            if(user != null)
            {
                if(user.Password == userLogin.Password) // Need to decrypt
                {
                    return mapper.Map<UserGet>(user);
                }
            }

            return null;
        }

        public UserGet UpdateUser(UserSet userSet)
        {
            var user = userDAL.UpdateUser(mapper.Map<UserMaster>(userSet));
            return mapper.Map<UserGet>(user);
        }
    }
}
