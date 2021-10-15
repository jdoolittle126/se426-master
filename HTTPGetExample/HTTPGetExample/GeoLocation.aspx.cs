using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;
using System.Net;


namespace HTTPGetExample
{
    public partial class GeoLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetInformation_Click(object sender, EventArgs e)
        {
            HttpWebRequest myHttpWebRequest = null;     //Declare an HTTP-specific implementation of the WebRequest class.
            HttpWebResponse myHttpWebResponse = null;   //Declare an HTTP-specific implementation of the WebResponse class
            XmlTextReader myXMLReader = null;           //Declare XMLReader

            try
            {

                txtResults.Text = "";
                XPathNavigator nav;
                XPathDocument docNav;


                String StockQuoteURL = "http://www.geoplugin.net/xml.gp?ip=" + txtIPAddress.Text;
                //Create Request
                myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(StockQuoteURL);
                myHttpWebRequest.Method = "GET";
                myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";

                //Get Response
                myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                ////Now load the XML Document
                //myXMLDocument = new XmlDocument();

                //Load response stream into XMLReader
                myXMLReader = new XmlTextReader(myHttpWebResponse.GetResponseStream());

                docNav = new XPathDocument(myXMLReader);
                // Create a navigator to query with XPath.
                nav = docNav.CreateNavigator();
                nav.MoveToRoot();
                nav.MoveToFirstChild();

                do
                {
                    //Find the first element.
                    if (nav.NodeType == XPathNodeType.Element)
                    {

                        ////Determine whether children exist.
                        //if (nav.HasChildren == true)
                        //{

                        //Move to the first child.
                        nav.MoveToFirstChild();

                        //Loop through all the children.
                        do
                        {
                            //Display the data.

                            txtResults.Text = txtResults.Text + nav.Name + " - " + nav.Value + Environment.NewLine;
                        } while (nav.MoveToNext());
                        //}
                    }
                } while (nav.MoveToNext());

            }
            catch (Exception myException)
            {
                throw new Exception("Error Occurred:", myException);
            }
            finally
            {
                myHttpWebRequest = null;
                myHttpWebResponse = null;
                myXMLReader = null;
            }
            //return myXMLDocument;
        }

        protected void btnXPath_Click(object sender, EventArgs e)
        {
            HttpWebRequest myHttpWebRequest = null;     //Declare an HTTP-specific implementation of the WebRequest class.
            HttpWebResponse myHttpWebResponse = null;   //Declare an HTTP-specific implementation of the WebResponse class
            XmlTextReader myXMLReader = null;           //Declare XMLReader

            try
            {

                txtResults.Text = "";
                XPathNavigator nav;
                XPathDocument docNav;


                String StockQuoteURL = "http://www.geoplugin.net/xml.gp?ip=" + txtIPAddress.Text;
                //Create Request
                myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(StockQuoteURL);
                myHttpWebRequest.Method = "GET";
                myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";

                //Get Response
                myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                ////Now load the XML Document
                //myXMLDocument = new XmlDocument();

                //Load response stream into XMLReader
                myXMLReader = new XmlTextReader(myHttpWebResponse.GetResponseStream());

                docNav = new XPathDocument(myXMLReader);
                // Create a navigator to query with XPath.
                nav = docNav.CreateNavigator();
                nav.MoveToRoot();
                nav.MoveToFirstChild();



                txtResults.Text = "Geoplugin Request = " + nav.SelectSingleNode("//geoplugin_request").Value + Environment.NewLine;
                XPathNodeIterator NodeIter;
                NodeIter = nav.Select("//geoPlugin");                

                while (NodeIter.MoveNext())
                {
                    txtResults.Text = txtResults.Text + NodeIter.Current.SelectSingleNode("geoplugin_regionName").Name + " - " +
                        NodeIter.Current.SelectSingleNode("geoplugin_regionName").Value + Environment.NewLine;
                    txtResults.Text = txtResults.Text + NodeIter.Current.SelectSingleNode("geoplugin_timezone").Name + " - " +
                       NodeIter.Current.SelectSingleNode("geoplugin_timezone").Value + Environment.NewLine;
                }
            }
            catch (Exception myException)
            {
                throw new Exception("Error Occurred:", myException);
            }
            finally
            {
                myHttpWebRequest = null;
                myHttpWebResponse = null;
                myXMLReader = null;
            }
            //return myXMLDocument;
        }
    }
}