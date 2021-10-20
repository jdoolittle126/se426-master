using System;
using System.Net;
using System.Xml;
using System.Xml.XPath;

namespace w2_lab_2
{
    public partial class Home : System.Web.UI.Page
    {
        private const string ApiKey = "7-qMSmCYhmZGQW_draCRh1c9ShSRA55Ibc7xxfGbZuY";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Executes the web service call based on the URI query. Parses the result as
        /// XML and returns an XPath document. If the query failed, a document is returned
        /// with an 'error' node, that contains the error message.
        /// </summary>
        /// <param name="query">The web service call to execute</param>
        /// <returns></returns>
        private static XPathDocument AsXPathDocument(string query)
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

        protected void ButtonTrafficSearch_Click(object sender, EventArgs e)
        {
            const string coord1 = "41.59516329231707, -71.41325447946073";
            const string coord2 = "41.84722232607233, -71.70754839630209";

            var uri = $"https://traffic.ls.hereapi.com/traffic/6.3/incidents.xml?apiKey={ApiKey}&bbox={coord1};{coord2}&criticality=minor";
            var navigator = AsXPathDocument(uri).CreateNavigator();

            TrafficOutput.Text = "";
            TotalResultsOutput.Text = "";

            if (navigator.Evaluate("count(//error) > 0") is bool hasError && hasError)
            {
                TotalResultsOutput.Text = $"<p class='text-danger'>{navigator.Select("//error[1]").Current.Value}</p>";
                return;
            }

            if(navigator.Evaluate("count(//TRAFFIC_ITEM_DESCRIPTION[@TYPE='desc'])") is double count)
            {
                TotalResultsOutput.Text = $"<p class='text-success'>Total Items: {count}</p>";
            }

            var itemIterator = navigator.Select("//TRAFFIC_ITEM_DESCRIPTION[@TYPE='desc']");

            while(itemIterator.MoveNext())
            {
                TrafficOutput.Text += $"<p>{itemIterator.Current}</p>";
            }

        }

        /// <summary>
        /// Parses a postal-related request from geonames. Since both functions in
        /// part 2 of this activity output the same type of data, they have been combined into a single function.
        /// </summary>
        /// <param name="uri">The web service call to execute</param>
        private void GeoNameZipCodeQuery(string uri)
        {
            var navigator = AsXPathDocument(uri).CreateNavigator();

            ZipResultsOutput.Text = "";
            TotalZipOutput.Text = "";

            if (navigator.Evaluate("count(//error) > 0") is bool hasError && hasError)
            {
                TotalZipOutput.Text = $"<p class='text-danger'>{navigator.Select("//error[1]").Current.Value}</p>";
                return;
            }

            if (navigator.Evaluate("count(//code)") is double count)
            {
                ZipResultsOutput.Text = $"<p class='text-success'>Total Items: {count}</p>";
            }

            var itemIterator = navigator.Select("//code");

            while (itemIterator.MoveNext())
            {
                string lineItem = "";
                var node = itemIterator.Current;

                if (node.Evaluate("string(postalcode)") is string postalcode)
                {
                    lineItem += $"Postal Code: {postalcode}<br/>";
                }

                if (node.Evaluate("string(name)") is string city)
                {
                    lineItem += $"City: {city}<br/>";
                }

                ZipResultsOutput.Text += $"<p>{lineItem}</p>";
            }
        }

        protected void ButtonInZipCodeSearch_OnClick(object sender, EventArgs e)
        {
            GeoNameZipCodeQuery($"http://api.geonames.org/postalCodeSearch?postalcode={TextBoxZipCode.Text}&username=jdoolittle&style=full");
        }

        protected void ButtonNearZipCodeSearch_OnClick(object sender, EventArgs e)
        {
            GeoNameZipCodeQuery($"http://api.geonames.org/findNearbyPostalCodes?postalcode={TextBoxZipCode.Text}&radius=10&username=jdoolittle&style=full");
        }
    }
}