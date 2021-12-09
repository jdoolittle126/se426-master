using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using w8_in_class_2.Models;

namespace w8_in_class_2.Controllers
{
    public class ProductsController : ApiController
    {
        ProductModel[] products = new ProductModel[]
        {
            new ProductModel { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new ProductModel { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new ProductModel { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        // GET: api/Products
        public IEnumerable<ProductModel> Get()
        {
            return products;
        }

        // GET: api/Products/5
        public ProductModel Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product is null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return product;
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
