using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3_lab_3_client.ServiceReference1;

namespace w3_lab_3_client
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProxy = new NeitStoreOrdersServiceClient("BasicHttpBinding_INeitStoreOrdersService");


            Console.WriteLine("Doubling Order ID 1:" + serviceProxy.ReturnDoubleOrderId(1));
            var test = serviceProxy.GetOrder(1);
            Console.ReadKey();


        }
    }
}
