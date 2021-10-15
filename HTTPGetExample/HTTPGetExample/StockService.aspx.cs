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
    public partial class StockService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetStock_Click(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            HttpWebRequest myHttpWebRequest = null;     //Declare an HTTP-specific implementation of the WebRequest class.
            HttpWebResponse myHttpWebResponse = null;   //Declare an HTTP-specific implementation of the WebResponse class
            XmlTextReader myXMLReader = null;           //Declare XMLReader

            try
            {
                XPathNavigator nav;
                XPathDocument docNav;

             
                String StockQuoteURL = "https://ws.cdyne.com/delayedstockquote/delayedstockquote.asmx/GetQuote?StockSymbol=T&LicenseKey=0";
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

        protected void btnEasyWay_Click(object sender, EventArgs e)
        {
            XPathNavigator nav;

          
            String weatherURL = "https://ws.cdyne.com/delayedstockquote/delayedstockquote.asmx/GetQuote?StockSymbol=T&LicenseKey=0";
            XmlDocument myXMLDocument = new XmlDocument();

            myXMLDocument.Load(weatherURL);


            // Create a navigator to query with XPath.
            nav = myXMLDocument.CreateNavigator();
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

        protected void btnClearTextBox_Click(object sender, EventArgs e)
        {
            txtResults.Text = "";
        }

     
    }
}