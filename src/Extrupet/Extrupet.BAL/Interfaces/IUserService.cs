using Extrupet.BAL.Models;
using System;
using System.Collections.Generic;

namespace Extrupet.BAL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserGet> GetAllUsers();
        UserGet Login(UserLogin userLogin);
        UserGet CreateUser(UserSet userSet);
        UserGet UpdateUser(UserSet userSet);
        UserGet GetUserById(Guid userId);
        bool UpdateUserActivationStatus(UserGet userSet);
        bool UpdatePassword(UserPassword userSet);
    }
}
