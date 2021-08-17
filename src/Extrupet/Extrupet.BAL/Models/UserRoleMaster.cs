using Extrupet.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.BAL.Models
{
    public class UserRoleMasterBase
    {
        public byte RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleAlias { get; set; }
        public bool IsActive { get; set; }
    }
    public class UserRoleMasterSet : UserRoleMasterBase
    {
        
    }

    public class UserRoleMasterGet : UserRoleMasterBase
    {
       
    }

   
}
