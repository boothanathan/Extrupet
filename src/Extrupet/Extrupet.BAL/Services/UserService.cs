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

        public UserGet GetUserById(Guid userId)
        {
            var userMaster = userDAL.GetUser(userId);
            return mapper.Map<UserGet>(userMaster);
        }
        public UserDetailsGet GetUserDetailsGetById(Guid userId)
        {
            var userMaster = userDAL.GetUser(userId);
            return mapper.Map<UserDetailsGet>(userMaster);
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
            var user = userDAL.GetUserFromLoginId(userLogin.LoginId);
            if (user != null)
            {
                if (user.Password == userLogin.Password) // Need to decrypt
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

        public bool UpdateUserActivationStatus(UserGet userGet)
        {
            var updatedUser = UpdateUser(mapper.Map<UserSet>(userGet));
            return updatedUser != null && updatedUser.IsActive == userGet.IsActive;
        }

        public bool UpdatePassword(UserPassword userPassword)
        {
            var userMaster = userDAL.GetUser(userPassword.UserId);
            var user = mapper.Map<UserSet>(userMaster);
            if (user.Password == userPassword.OldPassword)
            {
                user.Password = userPassword.NewPassword;
                UpdateUser(user);
                return true;
            }

            throw new PasswordNotMatchException();
        }

       
    }
}
