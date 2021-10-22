using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace w3_group_1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ContactManager : IContactManager
    {

        public ContactInformation GetContactInformation(string lastName)
        {
            return new ContactInformation()
            {
                firstName = "Jonathan",
                lastName = "Doolittle",
                emailAddress = "jjdoolittle@email.neit.edu",
                faxNumber = "1234561234",
                phoneNumber = "1234561234"
            };
        }

        public int GetNumberOfContacts()
        {
            return 5;
        }

    }
}
