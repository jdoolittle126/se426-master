using System.Collections.Generic;
using System.Web.Http;
using w8_in_class_2.Models;

namespace w8_in_class_2.Controllers
{
    public class OrdersController : ApiController
    {

        ///////////////////////
        // SERVICE METHODS
        ///////////////////////

        /// <returns>The total number of orders in the XML file</returns>
        [HttpGet]
        public int GetNumberOfOrders()
        {
            return OrderNavigatorSingleton.Instance.OrderNavigator.Evaluate($"count(//Order)") is double total ? (int)total : 0;
        }

        /// <param name="id">The ID of the order</param>
        /// <returns>The total cost of the given order</returns>
        [HttpGet]
        public double GetTotalCostForAnOrder(int id)
        {
            return OrderNavigatorSingleton.Instance.OrderNavigator.Evaluate($"sum({OrderUtils.SelectOrderQuery(id)}//TotalCost)") is double total ? total : 0.0;
        }

        /// <param name="id">The ID of the order</param>
        /// <returns>A list of OrderItem contained in the given order</returns>
        [HttpGet]
        public List<OrderItem> GetItemListForOrder(int id)
        {

            var itemList = new List<OrderItem>();
            try
            {
                var itemIterator = OrderNavigatorSingleton.Instance.OrderNavigator.Select($"{OrderUtils.SelectOrderQuery(id)}/Items/Item");
                while (itemIterator.MoveNext())
                {
                    var node = itemIterator.Current;

                    var orderItem = new OrderItem
                    {
                        // The * 1 forces the eval to try and evaluate as a number
                        Description = node?.Evaluate("string(Description)") as string,
                        PartNo = node?.Evaluate("string(PartNo)") as string,
                        UnitPrice = node?.Evaluate("UnitPrice/text()*1") is double price ? price : 0,
                        TotalCost = node?.Evaluate("TotalCost/text()*1") is double cost ? cost : 0,
                        Quantity = node?.Evaluate("Quantity/text()*1") is double quantity ? (int)quantity : 0,
                        Options = new CustomerOptions()
                        {
                            Size = node?.Evaluate("string(CustomerOptions/Size)") as string,
                            Color = node?.Evaluate("string(CustomerOptions/Color)") as string
                        }
                    };

                    itemList.Add(orderItem);
                }
            }
            catch
            {
                // ignored
            }

            return itemList;

        }

        /// <param name="id">The case-sensitive part number</param>
        /// <returns>The total quantity of this part purchased in all orders</returns>
        [HttpGet]
        public int HowManyOrderedForAPartNo(string id)
        {
            return OrderNavigatorSingleton.Instance.OrderNavigator?.Evaluate($"sum(//Item[PartNo[text() = '{id}']]/Quantity)") is double count
                ? (int)count : 0;
        }

    }
}
