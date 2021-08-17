using Extrupet.BAL.Models;
using System.Collections.Generic;

namespace Extrupet.BAL.Interfaces
{
    public interface IUserRoleMasterService
    {
        IEnumerable<UserRoleMasterGet> GetUserRoles();
    }
}
