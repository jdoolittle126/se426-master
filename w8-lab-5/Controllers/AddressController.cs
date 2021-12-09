using System.Web.Http;
using w8_in_class_2.Models;

namespace w8_in_class_2.Controllers
{
    public class AddressController : ApiController
    {

        /// <param name="id">The ID of the order</param>
        /// <returns>An OrderAddress object will the billing address of the given order. If the order cannot be found
        /// an empty object is returned.</returns>
        [HttpGet]
        public AddressModel GetBillingAddressForAnOrder(int id)
        {
            return OrderUtils.AsOrderAddress(OrderNavigatorSingleton.Instance.OrderNavigator, id, "BillingInformation");
        }
    }
}
