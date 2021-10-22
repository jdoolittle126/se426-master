using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml.XPath;

namespace w3_lab_3
{
    
    public class OrderService : IOrderService
    {

        private readonly XPathNavigator _orderNavigator;


        private OrderService()
        {
            _orderNavigator = LoadInvoiceXml().CreateNavigator();
        }


        /// <returns>The total number of orders in the XML file</returns>
        public int GetNumberOfOrders()
        {
            return _orderNavigator.Evaluate($"count(//Order)") is double total ? (int) total : 0;
        }


        /// <param name="orderId">The ID of the order</param>
        /// <returns>The total cost of the given order</returns>
        public double GetTotalCostForAnOrder(int orderId)
        {
            return _orderNavigator.Evaluate($"sum({SelectOrderQuery(orderId)}//TotalCost)") is double total ? total : 0.0;
        }

        /// <param name="orderId">The ID of the order</param>
        /// <returns>A list of OrderItem contained in the given order</returns>
        public List<OrderItem> GetItemListForOrder(int orderId)
        {

            var itemList = new List<OrderItem>();
            try
            {
                var itemIterator = _orderNavigator.Select($"{SelectOrderQuery(orderId)}/Items/Item");
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

        /// <param name="partNo">The case-sensitive part number</param>
        /// <returns>The total quantity of this part purchased in all orders</returns>
        public int HowManyOrderedForAPartNo(string partNo)
        {
            return _orderNavigator?.Evaluate($"sum(//Item[PartNo[text() = '{partNo}']]/Quantity)") is double count
                ? (int)count : 0;
        }

        /// <param name="orderId">The ID of the order</param>
        /// <returns>An OrderAddress object will the billing address of the given order. If the order cannot be found
        /// an empty object is returned.</returns>
        public OrderAddress GetBillingAddressForAnOrder(int orderId)
        {
            return AsOrderAddress(orderId, "BillingInformation");
        }

        /// <summary>
        /// Returns the query as an OrderAddress object, if it is valid. Returns a
        /// blank OrderAddress is the query cannot be evaluated.
        /// </summary>
        /// <param name="orderId">The ID of the order</param>
        /// <param name="query">The XPath or single node name (i.e. BillingAddress, etc.)</param>
        /// <returns></returns>
        private OrderAddress AsOrderAddress(int orderId, string query)
        {
            var orderAddress = new OrderAddress();
            try
            {
                var addressSelect = _orderNavigator.SelectSingleNode(SelectOrderQuery(orderId))?.SelectSingleNode(query);

                orderAddress.Name = addressSelect?.Evaluate("string(Name)") as string;
                orderAddress.Address = addressSelect?.Evaluate("string(Address)") as string;
                orderAddress.City = addressSelect?.Evaluate("string(City)") as string;
                orderAddress.State = addressSelect?.Evaluate("string(State)") as string;
                orderAddress.Zip = addressSelect?.Evaluate("string(ZipCode)") as string;
            }
            catch
            {
                // ignored
            }

            return orderAddress;
        }

        /// <summary>
        /// Returns the XPath to select a single order
        /// </summary>
        /// <param name="orderId">The ID of the order to select</param>
        /// <returns>The query for the specified order</returns>
        private static string SelectOrderQuery(int orderId)
        {
            return $"//Order[@id = '{orderId}']";
        }

        /// <summary>
        /// Loads the orders XML document
        /// </summary>
        /// <returns>An XPathDocument from the order XML file</returns>
        private static XPathDocument LoadInvoiceXml()
        {
            string directory = HttpContext.Current.Server.MapPath(".");
            string strFilename = directory + "\\" + "OrderInfoLab3.xml";
            return new XPathDocument(strFilename);
        }
    }
}
