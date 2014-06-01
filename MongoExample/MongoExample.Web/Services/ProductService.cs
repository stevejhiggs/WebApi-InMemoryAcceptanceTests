using MongoDB.Driver.Linq;
using MongoExample.Web.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoExample.Web.Storage;

namespace MongoExample.Web.Services
{
    public class ProductService
    {
        public List<Product> GetAllProducts()
        {
            var collection = MongoConnection.GetCollection<ProductDto>("Products");
            var storedProducts = collection.AsQueryable().ToList();

			List<Product> products = new List<Product>();

			foreach (var storedProduct in storedProducts)
			{
				products.Add(new Product() {
					Id = storedProduct.Id,
					Name = storedProduct.Name,
					HashedName = HashName(storedProduct.Name)
				});
			}

            return products;
        }

        public Product AddProduct(Product product)
        {
			var productDto = new ProductDto() 
			{
				Id = product.Id,
				Name = product.Name
			};

            var collection = MongoConnection.GetCollection<ProductDto>("Products");
			collection.Save(productDto);
            return product;
        }

		private string HashName(string name)
		{
			using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
			{
				byte[] retVal = md5.ComputeHash(Encoding.Unicode.GetBytes(name));
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < retVal.Length; i++)
				{
					sb.Append(retVal[i].ToString("x2"));
				}

				return sb.ToString();
			}
		}
    }
}