using System;
using System.IO;
using System.Xml.XPath;

namespace w1_in_class_1
{
    public partial class Home : System.Web.UI.Page
    {
        private XPathNavigator _navigator;
        private XPathDocument _document;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Attempts to load the XML in the textbox
        /// </summary>
        private bool TryLoadXml()
        {
            try
            {
                using (var stringReader = new StringReader(textBoxXmlInput.Text))
                {
                    _document = new XPathDocument(stringReader);
                    _navigator = _document.CreateNavigator();
                }
            } catch (Exception)
            {
                AppendResult("Invalid XML!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Wraps the given string in a div tag
        /// </summary>
        private static string AsDiv(string value)
        {
            return $"<div class='whitespace'>{value}</div>";
        }

        /// <summary>
        /// Appends the command to the mock console
        /// </summary>
        private void AppendCommand(string command)
        {
            outputRegion.Text += AsDiv($">{command}");
        }

        /// <summary>
        /// Appends the result to the mock console
        /// </summary>
        private void AppendResult(string result)
        {
            outputRegion.Text += AsDiv($"   {result}");
        }

        /// <summary>
        /// Displays all of the contacts present in the given iterator
        /// </summary>
        private void DisplayContacts(XPathNodeIterator iterator)
        {
            while (iterator.MoveNext())
            {
                var node = iterator.Current;

                AppendResult(node.Name + " (gender: " + node.GetAttribute("gender", node.NamespaceURI) + ")");

                node.MoveToFirstChild();
                do
                {
                    AppendResult("   - " + node.Name + ": " + node.Value);
                } while (node.MoveToNext());
            }
        }


        //////////////////////
        /// Click Listeners //
        //////////////////////

        protected void ButtonClearDisplay_Click(object sender, EventArgs e)
        {
            outputRegion.Text = "";
        }

        protected void ButtonDisplayDateVersion_Click(object sender, EventArgs e)
        {
            AppendCommand("select VERSION");

            if (!TryLoadXml()) return;

            var nodeIterator = _navigator.Select("//version[1]/*");
            
            while (nodeIterator.MoveNext())
            {
                AppendResult(nodeIterator.Current.Name + ": " + nodeIterator.Current);
            }

        }

        protected void ButtonInfoOnContact_Click(object sender, EventArgs e)
        {
            AppendCommand("select CONTACTS");

            if (!TryLoadXml()) return;

            var nodeIterator = _navigator.Select("//contact");

            DisplayContacts(nodeIterator);
        }

        protected void ButtonOnlyMaleInfo_Click(object sender, EventArgs e)
        {
            AppendCommand("select CONTACTS where gender=M");

            if (!TryLoadXml()) return;
            

            var nodeIterator = _navigator.Select("//contact[@gender='M']");
            DisplayContacts(nodeIterator);
        }

        protected void ButtonSpecificLastName_Click(object sender, EventArgs e)
        {
            AppendCommand($"select CONTACTS where last={textBoxSpecificLastName.Text}");

            if (!TryLoadXml()) return;

            var nodeIterator = _navigator.Select($"//contact[last='{textBoxSpecificLastName.Text}']");
            DisplayContacts(nodeIterator);
        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (!fileUpload.HasFile) return;

            using (var fileReader = new StreamReader(fileUpload.PostedFile.InputStream))
            {
                textBoxXmlInput.Text = fileReader.ReadToEnd();
            }
        }
    }
}