using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace w3_lab_3
{
    
    [ServiceContract]
    public interface IBankingService
    {

        [OperationContract]
        float ReturnAmountEarned(float balance, float interest);

        [OperationContract]
        AccountInformation[] GetAccountInformation();
    }


    [DataContract]
    public class AccountInformation
    {
        [DataMember] 
        public string AccountNumber { get; set; }
        [DataMember] 
        public string AccountType { get; set; }
        [DataMember] 
        public double CurrentAmount { get; set; }
    }

}
