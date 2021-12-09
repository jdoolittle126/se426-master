using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_group_1_client
{
    class Program
    {
        static void Main(string[] args)
        {
            // OperationOrderClient proxy = new OperationOrderClient("BasicHttpBinding_IOperationOrder");
            OperationOrdService.OperationOrderClient proxy = new OperationOrdService.OperationOrderClient("WSHttpBinding_IOperationOrder");
            proxy.Open();
            int a = 5;
            int b = 6;
            int result;
            //result = proxy.Add(a, b);
            proxy.Initialize(5);

            result = proxy.Add(a, b);

            Console.WriteLine("add result : {0}", result);
            result = proxy.Add(a, b);
            Console.WriteLine("add result : {0}", result);
            Console.WriteLine("Press enter to finish");
            Console.ReadLine();
        }
    }
}
