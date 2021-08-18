using Extrupet.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extrupet.BAL.Utilities;

namespace Extrupet.BAL.Models
{
    public class UserBase
    {

        public System.Guid UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required] 
        public string EmailId { get; set; }
        public string EmployeeId { get; set; }
        [Required]
        public byte RoleId { get; set; }
        public bool IsActive { get; set; }
        
        public Guid LastUpdatedById { get; set; }
    }


    public class UserSet : UserBase
    {
        //Encryption needed before sending to db    
        public string Password { get; set; }
    }

    public class UserGet : UserBase
    {       
        public DateTime LastUpdatedOnUTC { get; set; }
        public DateTime LastUpdatedOnLocalTime
        {
            get
            {
                return LastUpdatedOnUTC.GetLocalDateTimeFromUtc();
            }
        }
    }


    public class UserLogin
    {
        public string LoginId { get; set; }
        public string Password { get; set; }
    }

    public class UserActivationStatus
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public bool Status { get; set; }
    }

    public class UserPassword
    {
        public Guid UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

}
