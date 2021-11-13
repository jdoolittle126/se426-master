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

namespace w5_midterm_part_2
{

    public class NeitStoreOrdersService : INeitStoreOrdersService
    {
        public Order GetOrder(int orderId)
        {

            return new Order
            {
                OrderId = 1,
                ShopperAddress = "101 Main Street",
                ShopperName = "Sam Spade",
                Items = new OrderItem[] {
                    new OrderItem
                    {
                        Name = "T-Shirt",
                        Cost = 22.00,
                        Sku = "T001",
                        Options = new OrderItemOptions
                        {
                            Color = "green",
                            Size = "S"
                        }
                    },
                    new OrderItem
                    {
                        Name = "Pants",
                        Cost = 12.00,
                        Sku = "T002"
                    },
                }

            };
        }

        public int ReturnDoubleOrderId(int orderId)
        {
            return orderId * 2;
        }
    }
}
