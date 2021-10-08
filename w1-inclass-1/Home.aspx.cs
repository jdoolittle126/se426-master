using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.XPath;

namespace w1_inclass_1
{
    public partial class Home : System.Web.UI.Page
    {

        XPathNavigator navigator;
        XPathDocument document;
        XPathNodeIterator nodeIterator;

        protected void Page_Load(object sender, EventArgs e)
        {

                
        }
        protected bool TryLoadXml(String xPath)
        {
            try
            {
                using (StringReader stringReader = new StringReader(textBoxXmlInput.Text))
                {
                    document = new XPathDocument(stringReader);
                    navigator = document.CreateNavigator();
                }
            } catch (Exception)
            {
                textBoxOutput.Text = "Invalid XML!";
                return false;
            }
            return true;
        }

        protected void ExecuteXPath(String xPath)
        {
            if (TryLoadXml("//version[1]/*"))
            {
                nodeIterator = navigator.Select(xPath);
                textBoxOutput.Text += $"\n ==== [QUERY = \"{xPath}\"] ===\n";
                while (nodeIterator.MoveNext())
                {
                    textBoxOutput.Text += nodeIterator.Current + "\n";
                }
            }

        }

        protected void ButtonClearDisplay_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = "";
        }

        protected void ButtonDisplayDateVersion_Click(object sender, EventArgs e)
        {
            ExecuteXPath("//version[1]/*");
        }

        protected void ButtonInfoOnContact_Click(object sender, EventArgs e)
        {
            ExecuteXPath("//contact"); //TODO
        }

        protected void ButtonOnlyMaleInfo_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonSpecificLastName_Click(object sender, EventArgs e)
        {

        }
    }
}