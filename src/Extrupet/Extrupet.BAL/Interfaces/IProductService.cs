using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extrupet.BAL.Models;

namespace Extrupet.BAL.Interfaces
{
    public interface IProductService
    {
        ProductGet SaveProduct(ProductSet productSet);
        IEnumerable<ProductGet> GetAllProducts();
        ProductDetailsGet GetProductById(Guid productId);
    }
}
