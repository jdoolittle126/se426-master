using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Xml.XPath;


namespace WebAPIRouting.Controllers
{
    public class OrdersController : ApiController
    {

        // GET: Orders
        public string Get()
        {
            return "Basic Get";
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "Get with id = " + id.ToString();
        }

        [Route("customers/{customerId}/orders")]
        [HttpGet]
        public string FindOrdersByCustomer(int customerId) {
           
            return "CustomerID = " + customerId.ToString(); 
        }


        [Route("customers/{customerId}/orders/{orderId}")]
        public string GetOrderByCustomer(int customerId, int orderId)
        {
       
            return "CustomerID = " + customerId.ToString() + " " + "Order = " + orderId.ToString(); ;
        }

        [Route("api/users/{id:int}")]
        public string GetUserById(int id) {
          
            return "Id = " + id.ToString();
        }

        [Route("users/{name}")]
        public string GetUserByName(string name) {
           
            return "Name = " + name.ToString();
        }

        [Route("api/users/Id/{lcid:int?}")]
        public string GetUsersOptionalID(int lcid = 1033)
        {
            return "Get Users Optional with id of " + lcid.ToString();
        } 

    }
}