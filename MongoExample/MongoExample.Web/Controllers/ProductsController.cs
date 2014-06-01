using MongoExample.Web.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MongoExample.Web.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductService Service = new ProductService();

        public IEnumerable<Product> Get()
        {
            var products = Service.GetAllProducts();
			return products;
        }

        public Product Post(AddRequestViewModel request)
        {
			Product addedProduct = new Product();
			addedProduct.Id = Guid.NewGuid();
			addedProduct.Name = request.Name;
			Service.AddProduct(addedProduct);
			return addedProduct;
        }
    }
}
