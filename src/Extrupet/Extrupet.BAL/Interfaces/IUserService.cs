using Extrupet.BAL.Models;
using System.Collections.Generic;

namespace Extrupet.BAL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserGet> GetUsers();
        UserGet SaveUsers(UserSet user);
    }
}
