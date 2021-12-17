using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.XPath;

namespace WebAPIRouting.Models
{
    public class OrderModels
    {
        public class AddressModel
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }

        }

        public class CustomerOptions
        {
            public string Size { get; set; }
            public string Color { get; set; }
        }

        public class OrderItem
        {
            public string PartNo { get; set; }
            public string Description { get; set; }
            public double UnitPrice { get; set; }
            public int Quantity { get; set; }
            public double TotalCost { get; set; }
            public CustomerOptions Options { get; set; }
        }

        public sealed class OrderNavigatorSingleton
        {
            private static readonly Lazy<OrderNavigatorSingleton> Lazy =
                new Lazy<OrderNavigatorSingleton>(() => new OrderNavigatorSingleton());

            public readonly XPathNavigator OrderNavigator = OrderUtils.LoadInvoiceXml().CreateNavigator();

            public static OrderNavigatorSingleton Instance => Lazy.Value;

            private OrderNavigatorSingleton()
            {
            }
        }

        public static class OrderUtils
        {

            public static AddressModel GetAddress(bool isShipping, string City, string State)
            {
                AddressModel oBilling = new AddressModel();
                try
                {
                    XPathNavigator nav;
                    XPathDocument docNav;
                    XPathNodeIterator NodeIter;

                    //        Open the XML.
                    String rootPath = System.Web.HttpContext.Current.Server.MapPath("~");
                    string strFilename = rootPath + "\\OrderInfo.xml";
                    docNav = new XPathDocument(strFilename);

                    //        Create a navigator to query with XPath.
                    nav = docNav.CreateNavigator();

                    //        Select the node and place the results in an iterator.
                    //        
                    string type = (isShipping) ? "Shipping" : "Billing";
                    String selectString = $"//Order/{type}Information[City='" + City + "' and State='" + State + "']";
                    NodeIter = nav.Select(selectString);
                    NodeIter.MoveNext();
                    XPathNavigator BillingInformation = NodeIter.Current;
                    oBilling.Name = BillingInformation.SelectSingleNode("Name").Value;
                    oBilling.Address = BillingInformation.SelectSingleNode("Address").Value;
                    oBilling.City = BillingInformation.SelectSingleNode("City").Value;
                    oBilling.State = BillingInformation.SelectSingleNode("State").Value + " ";
                    oBilling.ZipCode = BillingInformation.SelectSingleNode("ZipCode").Value;

                }
                catch
                {

                    oBilling.Name = "Can Not Get Value";
                    oBilling.Address = "Can Not Get Value";
                    oBilling.City = "Can Not Get Value";
                    oBilling.State = "Can Not Get Value";
                    oBilling.ZipCode = "Can Not Get Value";


                }

                return oBilling;
            }

            /// <summary>
            /// Returns the query as an OrderAddress object, if it is valid. Returns a
            /// blank OrderAddress is the query cannot be evaluated.
            /// </summary>
            /// <param name="orderId">The ID of the order</param>
            /// <param name="query">The XPath or single node name (i.e. BillingAddress, etc.)</param>
            /// <returns></returns>
            public static AddressModel AsOrderAddress(XPathNavigator navigator, int orderId, string query)
            {
                var orderAddress = new AddressModel();
                try
                {
                    var addressSelect = navigator.SelectSingleNode(SelectOrderQuery(orderId))?.SelectSingleNode(query);

                    orderAddress.Name = addressSelect?.Evaluate("string(Name)") as string;
                    orderAddress.Address = addressSelect?.Evaluate("string(Address)") as string;
                    orderAddress.City = addressSelect?.Evaluate("string(City)") as string;
                    orderAddress.State = addressSelect?.Evaluate("string(State)") as string;
                    orderAddress.ZipCode = addressSelect?.Evaluate("string(ZipCode)") as string;
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
            public static string SelectOrderQuery(int orderId)
            {
                return $"//Order[@id = '{orderId}']";
            }

            /// <summary>
            /// Loads the orders XML document
            /// </summary>
            /// <returns>An XPathDocument from the order XML file</returns>
            public static XPathDocument LoadInvoiceXml()
            {
                string directory = HttpContext.Current.Server.MapPath("~");
                string strFilename = directory + "\\OrderInfo.xml";
                return new XPathDocument(strFilename);
            }
        }
    }
}