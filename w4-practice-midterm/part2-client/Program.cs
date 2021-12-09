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
            var bankProxy = new BankingService.BankingServiceClient("BasicHttpBinding_IBankingService");
            Console.WriteLine(bankProxy.ReturnAmountEarned(100, 0.05f));
            var test = bankProxy.GetAccountInformation();
            Console.ReadKey();


        }
    }
}
