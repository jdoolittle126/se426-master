using System;
using System.IO;
using System.Text;
using System.Web;
using System.Xml.XPath;

namespace part3
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static XPathDocument LoadXml()
        {
            string directory = HttpContext.Current.Server.MapPath(".");
            string strFilename = directory + "\\" + "catalog.xml";
            return new XPathDocument(strFilename);
        }

        private static string WithTag(string input, string tag)
        {
            return $"<{tag}>{input}</{tag}>";
        }

        // price & gender  //catalog_item[price < 40]
        // item number (already selected) //catalog_item[size[@description='Small']]/item_number


        protected void ButtonSearch_OnClick(object sender, EventArgs e)
        {
            CatalogOutput.Text = WithTag("Price is < $40", "div");
            var navigator = LoadXml().CreateNavigator();

            // Item Price < $40
            var priceIterator = navigator.Select("//catalog_item[price < 40]");
            while (priceIterator.MoveNext())
            {
                var node = priceIterator.Current;

                CatalogOutput.Text += WithTag($"Gender = {node.GetAttribute("gender", node.NamespaceURI)}, " +
                                              $"Price = {node.Evaluate("price/text()*1"):C}", 
                                              "div");

            }

            CatalogOutput.Text += WithTag("Item has 'Small' size option", "div");

            // Size = Small
            var sizeIterator = navigator.Select("//catalog_item[size[@description='Small']]/item_number");
            while (sizeIterator.MoveNext())
            {
                CatalogOutput.Text += WithTag($"Item Number = {sizeIterator.Current.Value}", "div");
            }

        }
    }

}