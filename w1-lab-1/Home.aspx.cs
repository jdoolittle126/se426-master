using System;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml.XPath;

namespace w1_lab_1
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static string WithTag(string input, string tag)
        {
            return $"<{tag}>{input}</{tag}>";
        }

        private void GenerateInvoice(XPathNavigator navigator)
        {
            // Shipping
            var shippingIterator = navigator.Select("Order/ShippingInformation[1]/*");
            while (shippingIterator.MoveNext())
            {
                Shipping.Text += WithTag(shippingIterator.Current.Value, "div");
            }

            // Billing
            var billingIterator = navigator.Select("Order/BillingInformation[1]/*");
            while (billingIterator.MoveNext())
            {
                Billing.Text += WithTag(billingIterator.Current.Value, "div");
            }

            // Line Items
            var lineItemIterator = navigator.Select("//Items/Item");
            while (lineItemIterator.MoveNext())
            {
                var node = lineItemIterator.Current;
                var lineItem = new StringBuilder();

                lineItem
                    .Append(WithTag((string)node.Evaluate("string(PartNo)"), "td"))
                    .Append(WithTag((string)node.Evaluate("string(Description)"), "td"))
                    .Append("<td>");

                // Append the name of each option
                var optionsIterator = node.Select("CustomerOptions/*");
                while (optionsIterator.MoveNext())
                {
                    lineItem.Append(WithTag($"{optionsIterator.Current.Name}: {optionsIterator.Current.Value}", "div"));
                }

                lineItem
                    .Append("</td>")
                    .Append(WithTag((string)node.Evaluate("string(UnitPrice)"), "td"))
                    .Append(WithTag((string)node.Evaluate("string(Quantity)"), "td"))
                    .Append(WithTag((string)node.Evaluate("string(TotalCost)"), "td"));

                TableBody.Text += WithTag(lineItem.ToString(), "tr");
            }

            // Total Cost & Item Count
            if (navigator.Evaluate("sum(//Items/Item/TotalCost)") is double totalCost && 
                navigator.Evaluate("sum(//Items/Item/Quantity)") is double itemCount)
            {
                // Make a blank item line with just the totals
                var finalLine = new StringBuilder();
                finalLine
                    .Append(WithTag("", "td"))
                    .Append(WithTag("", "td"))
                    .Append(WithTag("", "td"))
                    .Append(WithTag("", "td"))
                    .Append(WithTag(itemCount.ToString(), "td"))
                    .Append(WithTag($"{totalCost:C2}", "td"));

                TableBody.Text += WithTag(finalLine.ToString(), "tr");
            }

        }

        //////////////////////
        /// Click Listeners //
        //////////////////////

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            UploadResult.Text = "";

            if (FileUpload.HasFile)
            {
                try
                {
                    using (var fileReader = new StreamReader(FileUpload.PostedFile.InputStream))
                    {
                        var document = new XPathDocument(fileReader);
                        var navigator = document.CreateNavigator();
                        GenerateInvoice(navigator);
                    }

                    return;
                }
                catch
                {
                    // ignored
                }
            }

            UploadResult.Text = "Upload Failed!";

        }

    }

}