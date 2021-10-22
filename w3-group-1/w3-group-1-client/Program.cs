using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w3_group_1_client.ContactExample;

namespace w3_group_1_client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");
            ContactExample.ContactManagerClient proxy = new ContactManagerClient("BasicHttpBinding_IContactManager");
            Console.WriteLine(proxy.GetNumberOfContacts());
            Console.ReadLine();


        }
    }
}
