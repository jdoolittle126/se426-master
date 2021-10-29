using System;
using System.Linq;
using System.Web;
using System.Xml.XPath;
using part1.BankingWebService;

namespace part1
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSearch_OnClick(object sender, EventArgs e)
        {

            var bankInformation = new BankingServiceSoapClient("BankingServiceSoap").GetBankInformation();

            TextboxAccountId.Text = bankInformation.AccountID;
            TextboxAccountOwner.Text = bankInformation.OwnerName;

            if (bankInformation.accounts is null)
            {
                TextboxTotal.Text = "Accounts is null?";
            }
            else
            {
                var total = bankInformation.accounts.Sum(bankInformationAccount => bankInformationAccount.Amount);
                TextboxTotal.Text = $"{total:C}";
            }



        }
    }

}