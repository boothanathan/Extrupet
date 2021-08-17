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
        [Required]
        public string Password { get; set; }
    }

    public class UserGet : UserBase
    {
        public string Password { get; set; } // Decryption needed.
        public DateTime LastUpdatedOnUTC { get; set; }
        public DateTime LastUpdatedOnLocalTime
        {
            get
            {
                return LastUpdatedOnUTC.GetLocalDateTimeFromUtc();
            }
        }
    }

   
}
