using Extrupet.BAL.Models;
using System.Collections.Generic;

namespace Extrupet.BAL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserGet> GetAllUsers();
        UserGet Login(UserLogin userLogin);
        UserGet CreateUser(UserSet userSet);
        UserGet UpdateUser(UserSet userSet);
    }
}
