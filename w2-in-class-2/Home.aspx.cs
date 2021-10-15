using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;

namespace w2_in_class_2
{
    public partial class Home : System.Web.UI.Page
    {

        const string apiKey = "lEpyKCmOjzurqyfOVQQqz0LBQZGRFQaI";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private XPathDocument AsXPathDocument(string query)
        {
            HttpWebRequest httpWebRequest;

            try
            {
                httpWebRequest = WebRequest.Create(query) as HttpWebRequest;
                httpWebRequest.Method = "GET";
                httpWebRequest.ContentType = "text/xml; encoding='utf-8'";

                var outputStream = httpWebRequest.GetResponse().GetResponseStream();
                var outputXml = new XmlTextReader(outputStream);
                return new XPathDocument(outputXml);
            } catch (Exception e)
            {
                string xml = $"<response><error>{e.Message}</error></response>";
                XmlDocument output = new XmlDocument();
                output.LoadXml(xml);

                return new XPathDocument(new XmlNodeReader(output));
            } finally
            {
                httpWebRequest = null;
            }


        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = TextBoxPoi.Text;
            string uri = $"https://api.tomtom.com/search/2/poiSearch/{searchTerm}.xml?lat=41.662258&lon=-71.450020&radius=5000&key={apiKey}";

            var navigator = AsXPathDocument(uri).CreateNavigator();

            PoiOutput.Text = "";
            TotalResultsOutput.Text = "";

            if (navigator.Evaluate("count(//error) > 0") is bool hasError && hasError)
            {
                TotalResultsOutput.Text = $"<p class='text-danger'>{navigator.Select("//error[1]").Current.Value}</p>";
                return;
            }

            if(navigator.Evaluate("string(//numResults[1])") is string count)
            {
                TotalResultsOutput.Text = $"Total Items: {count}";
            }

            var itemIterator = navigator.Select("//results/item");

            while(itemIterator.MoveNext())
            {
                string lineItem = "";
                var node = itemIterator.Current;

                if (node.Evaluate("string(poi/name)") is string name)
                {
                    lineItem += $"Name: {name}<br/>";
                }

                if (node.Evaluate("string(address/freeformAddress)") is string address)
                {
                    lineItem += $"Address: {address}<br/>";
                }

                if (node.Evaluate("string(poi/phone)") is string phone)
                {
                    lineItem += $"Phone: {phone} ";
                }

                PoiOutput.Text += $"<p>{lineItem}</p>";

            }

        }
    }
}