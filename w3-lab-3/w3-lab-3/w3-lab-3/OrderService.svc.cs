using System;
using System.Collections.Generic;
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

        public int GetNumberOfOrders()
        {
            return _orderNavigator.Evaluate($"count(//Order)") is double total ? (int) total : 0;
        }

        public double GetTotalCostForAnOrder(int orderId)
        {
            return _orderNavigator.Evaluate($"sum({SelectOrderQuery(orderId)}//TotalCost)") is double total ? total : 0.0;
        }

        public List<OrderItem> GetItemListForOrder(int orderId)
        {
            var itemList = new List<OrderItem>();
            try
            {
                var itemIterator = _orderNavigator.Select($"{SelectOrderQuery(orderId)}/Items/Item");
                while (itemIterator.MoveNext())
                {
                    var node = itemIterator.Current;
                    //TODO
                    var testing = node?.Evaluate("string(Name)");

                    var orderItem = new OrderItem
                    {
                        Description = node?.Evaluate("string(Name)") as string,
                        PartNo = node?.Evaluate("string(PartNo)") as string,
                        UnitPrice = node?.Evaluate("string(UnitPrice)") is double price ? price : 0,
                        Quantity = node?.Evaluate("string(Quantity)") is int quantity ? quantity : 0,
                        Options = new CustomerOptions()
                        {
                            Size = node?.Evaluate("string(CustomerOptions/Size)") as string,
                            Color = node?.Evaluate("string(CustomerOptions/Color)") as string
                        }
                    };

                    itemList.Add(orderItem);
                }
            }
            catch(Exception _)
            {
                // ignored
            }

            return itemList;

        }

        public int HowManyOrderedForAPartNo(string partNo)
        {
            if(_orderNavigator.Evaluate($"count(//Item/PartNo[text() = '{partNo}'])") is double count)
            {
                return (int) count;
            }

            return -1;
        }

        public OrderAddress GetBillingAddressForAnOrder(int orderId)
        {
            return AsOrderAddress(orderId, "BillingInformation");
        }

        /// <summary>
        /// Returns the query as an OrderAddress object, if it is valid. Returns a
        /// blank OrderAddress is the query cannot be evaluated.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="query">The XPath query to evaluate</param>
        /// <returns></returns>
        public OrderAddress AsOrderAddress(int orderId, string query)
        {
            var orderAddress = new OrderAddress();
            try
            {
                var addressSelect = _orderNavigator.SelectSingleNode(SelectOrderQuery(orderId)).SelectSingleNode(query);

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
        private string SelectOrderQuery(int orderId)
        {
            return $"//Order[@id = '{orderId}']";
        }

        /// <summary>
        /// Loads the orders XML document
        /// </summary>
        /// <returns>An XPathDocument from the order XML file</returns>
        private static XPathDocument LoadInvoiceXml()
        {
            var directory = HttpContext.Current.Server.MapPath(".");
            var strFilename = directory + "\\" + "OrderInfoLab3.xml";
            return new XPathDocument(strFilename);
        }
    }
}
