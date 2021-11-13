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
            string strFilename = directory + "\\" + "nutrition.xml";
            return new XPathDocument(strFilename);
        }

        private static string WithTag(string input, string tag)
        {
            return $"<{tag}>{input}</{tag}>";
        }

        // name & total calories  //food[fiber>2]
        // name //food[@type="meat"]


        protected void ButtonSearch_OnClick(object sender, EventArgs e)
        {
            Output.Text = WithTag("Fiber > 2", "div");
            var navigator = LoadXml().CreateNavigator();

            // Fiber > 2
            var fiberIterator = navigator.Select("//food[fiber>2]");
            while (fiberIterator.MoveNext())
            {
                var node = fiberIterator.Current;

                Output.Text += WithTag($"Name = {node.SelectSingleNode("name")}, " +
                                              $"Total Calories = {node.SelectSingleNode("calories")?.GetAttribute("total", node.NamespaceURI)}", 
                                              "div");


            }

            Output.Text += WithTag("Foods that are meats", "div");

            // Meats
            var sizeIterator = navigator.Select("//food[@type='meat']/name");
            while (sizeIterator.MoveNext())
            {

                Output.Text += WithTag($"Name = {sizeIterator.Current.Value}", "div");
            }

        }
    }

}