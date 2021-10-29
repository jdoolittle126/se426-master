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

namespace w3_lab_3
{

    public class BankingService : IBankingService
    {
        public AccountInformation[] GetAccountInformation()
        {
            return new[]
            {
                new AccountInformation
                {
                    AccountNumber = "123",
                    AccountType = "Checking",
                    CurrentAmount = 100.0
                },
                new AccountInformation
                {
                    AccountNumber = "999",
                    AccountType = "Money Market",
                    CurrentAmount = 250.0
                },
                new AccountInformation
                {
                    AccountNumber = "456",
                    AccountType = "Savings",
                    CurrentAmount = 50.0
                },
            };
        }

        public float ReturnAmountEarned(float balance, float interest)
        {
            return balance * interest;
        }
    }
}
