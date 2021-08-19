using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.BAL.Models
{
    public class ProductBase
    {
        public System.Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public byte GradeTypeId { get; set; }
        public System.Guid LastUpdatedBy { get; set; }
    }

    public class ProductSet : ProductBase { }
    public class ProductGet: ProductBase
    {
        public System.DateTime LastUpdatedOnUTC { get; set; }
    }
    public class ProductDetailsGet : ProductBase
    {
        public System.DateTime LastUpdatedOnUTC { get; set; }
    }
}
