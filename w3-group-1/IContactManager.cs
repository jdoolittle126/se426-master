using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace w3_group_1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IContactManager
    {


        [OperationContract]
        ContactInformation GetContactInformation(string lastName);

        [OperationContract]
        int GetNumberOfContacts();

    }

    [DataContract]
    public class ContactInformation
    {
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
        [DataMember]
        public string phoneNumber { get; set; }
        [DataMember]
        public string faxNumber { get; set; }
        [DataMember]
        public string emailAddress { get; set; }

    }

}
