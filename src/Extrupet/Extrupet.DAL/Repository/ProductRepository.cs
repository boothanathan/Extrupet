using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extrupet.DAL.Entity;

namespace Extrupet.DAL.Repository
{
    public class ProductRepository : GenericQuery<ProductMaster>
    {
        public ProductRepository(ExtrupetEntities context) : base(context)
        {

        }

        public IEnumerable<ProductMaster> GetAllProducts()
        {
            return base.GetQuery(null);
        }
        
        public ProductMaster GetProductById(Guid productId)
        {
            return base.GetQuery(x => x.ProductId == productId).FirstOrDefault();
        }

        public ProductMaster SaveProduct(ProductMaster productMaster)
        {
            productMaster.LastUpdatedOnUTC = DateTime.UtcNow;
            if (productMaster.ProductId == new Guid())
            {
                productMaster.ProductId = Guid.NewGuid();
                productMaster = base.Add(productMaster);
            }
            else
                productMaster = base.Update(productMaster);
            return productMaster;
        }
    }
}
