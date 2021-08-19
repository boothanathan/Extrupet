using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extrupet.BAL.Models;
using Extrupet.BAL.Utilities;
using Extrupet.BAL.Interfaces;
using Extrupet.DAL.Repository;
using Extrupet.DAL.Entity;

namespace Extrupet.BAL.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository productDAL;
        private readonly Mapper mapper;
        public ProductService()
        {
            productDAL = new ProductRepository(new ExtrupetEntities());
            mapper = new MapperProfile().Mapper;
        }

        public IEnumerable<ProductGet> GetAllProducts()
        {
            var productMasters = productDAL.GetAllProducts();
            var productGets = new List<ProductGet>();
            if (productMasters != null && productMasters.Count() > 0)
            {
                foreach (var pm in productMasters)
                {
                    productGets.Add(mapper.Map<ProductGet>(pm));
                }
            }
            return productGets;
        }

        public ProductDetailsGet GetProductById(Guid productId)
        {
            var productMaster = productDAL.GetProductById(productId);
            return mapper.Map<ProductDetailsGet>(productMaster);
        }

        public ProductGet SaveProduct(ProductSet productSet)
        {
            var productMaster = mapper.Map<ProductMaster>(productSet);
            productMaster.LastUpdatedOnUTC = DateTime.UtcNow;
            productMaster = productDAL.SaveProduct(productMaster);
            return mapper.Map<ProductGet>(productMaster);
        }
    }
}
