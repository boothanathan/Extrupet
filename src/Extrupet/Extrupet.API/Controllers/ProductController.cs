using Extrupet.BAL.Interfaces;
using Extrupet.BAL.Models;
using Extrupet.BAL.Services;
using Extrupet.BAL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Extrupet.API.Controllers
{
    [RoutePrefix("Api/Product")]
    public class ProductController : ApiController
    {
        private readonly IProductService productService = new ProductService();       
        private ExtrupetResponse response;

        [HttpPost]
        [Route("SaveProduct")]
        public IHttpActionResult SaveProduct(ProductSet productSet)
        {
            if (ModelState.IsValid)
            {
                var productGet = productService.SaveProduct(productSet);
                response = new ExtrupetResponse { Status = true, ResponseObject = productGet };
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        
        [HttpGet]
        [Route("GetAllProducts")]
        public IHttpActionResult GetAllProducts()
        {
            var productGets = productService.GetAllProducts();
            response = new ExtrupetResponse { Status = true, ResponseObject = productGets };
            return Ok(response);
        }

        [HttpGet]
        [Route("GetProductById/{Id}")]
        public IHttpActionResult GetProduct(Guid Id)
        {
            var productDetailsGet = productService.GetProductById(Id);
            response = new ExtrupetResponse { Status = true, ResponseObject = productDetailsGet };
            return Ok(response);
        }
    }
}
