using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3_lab_3_client
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderProxy = new OrderService.OrderServiceClient("BasicHttpBinding_IOrderService");

            // Billing Address
            Console.WriteLine("Billing Information for Order 1");

            var billingAddress = orderProxy.GetBillingAddressForAnOrder(1);

            Console.WriteLine($" Name = {billingAddress.Name}\n Address = {billingAddress.Address}\n " +
                              $"City = {billingAddress.City}\n State = {billingAddress.State}\n " +
                              $"Zip = {billingAddress.Zip}");

            // Total Orders
            Console.WriteLine("Total Number of Orders");
            Console.WriteLine($" {orderProxy.GetNumberOfOrders()}");

            // Total Number of JETSWEATER Parts
            Console.WriteLine("Total Number of JETSWEATER's Ordered");
            Console.WriteLine($" {orderProxy.HowManyOrderedForAPartNo("JETSWEATER")}");

            // Order Details
            Console.WriteLine("Order 1 Details");
            foreach (var item in orderProxy.GetItemListForOrder(1))
            {
                Console.WriteLine($" {item.PartNo} - {item.Description} x {item.Quantity} ({item.TotalCost:C})");
            }

            // Total Cost of Order
            Console.WriteLine("Total Cost of Order 1");
            Console.WriteLine($" {orderProxy.GetTotalCostForAnOrder(1):C}");

            Console.WriteLine("Press Any Key to Continue!");
            Console.ReadLine();

        }
    }
}
