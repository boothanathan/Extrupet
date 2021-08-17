using Extrupet.BAL.Utilities;
using Extrupet.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.BAL.Models
{
    public class CompanyDataBase
    {
        public byte CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
    }

    public class CompanyDataSet : CompanyDataBase
    {

    }

    public class CompanyDataGet : CompanyDataBase
    {
        public Guid LastUpdatedBy { get; set; }
        public System.DateTime LastUpdatedOnUTC { get; set; }
        public DateTime LastUpdatedOnLocalTime
        {
            get
            {
                return LastUpdatedOnUTC.GetLocalDateTimeFromUtc();
            }
        }
    }


}
