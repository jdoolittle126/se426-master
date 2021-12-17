using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIRouting.Models;

namespace WebAPIRouting.Controllers
{
    public class AddressController : ApiController
    {
        [HttpGet]
        [Route("address/{City}/{State}/billing")]
        public OrderModels.AddressModel GetBillingAddress(string City, string State)
        {
            return OrderModels.OrderUtils.GetAddress(false, City, State);
        }

        [HttpGet]
        [Route("address/{City}/{State}/shipping")]
        public OrderModels.AddressModel GetShippingAddress(string City, string State)
        {
            return OrderModels.OrderUtils.GetAddress(true, City, State);
        }

        /// <param name="id">The ID of the order</param>
        /// <returns>An OrderAddress object will the billing address of the given order. If the order cannot be found
        /// an empty object is returned.</returns>
        [HttpGet]
        public OrderModels.AddressModel GetBillingAddressForAnOrder(int id)
        {
            return OrderModels.OrderUtils.AsOrderAddress(OrderModels.OrderNavigatorSingleton.Instance.OrderNavigator, id, "BillingInformation");
        }
    }
}
