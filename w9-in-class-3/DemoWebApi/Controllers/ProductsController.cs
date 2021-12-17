using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoWebApi.Models;

namespace DemoWebApi.Controllers
{
    public class ProductsController : ApiController
    {

        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        // GET: api/Products
        //public IEnumerable<Product> GetProducts()
        public IEnumerable<Product> Get()
        {
            return products;

        }

        // GET: api/Products/5
        // rename to FindProductByID(int id) and it will go to the generic Get routine
        [HttpGet]   
        [HttpPost]
        [ActionName("BruceProduct")]
        public Product GetProductByID(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;

        }
        [HttpGet]
        public Product MyNewGetProductByID(int ProductID)
        {
            var product = products.FirstOrDefault((p) => p.Id == ProductID);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;

        }

        public Product GetProductByName(string ProductName)
        {
            var product = products.FirstOrDefault((p) => p.Name == ProductName);
            if (product == null)
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
