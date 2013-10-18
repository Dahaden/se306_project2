using Team_Roasters;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Markup;
using System.IO;
using System;
using HtmlAgilityPack;
using System.Text;
using System.Xml;
using System.Net;
namespace Team_Roasters.Screens
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Screen
    {
        public HomeScreen(SurfaceWindow1 parentWindow) : base(parentWindow)
        {
            InitializeComponent();
            getNews();
            GetEvents();
        }

        /// <summary>
        /// Opens new window containing the What We Do info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void What_we_do_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.pushScreen(new WhatWeDo(parentWindow));
        }

        /// <summary>
        /// Opens new window containing the Family Support info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FamilyButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.pushScreen(new FamilySupportScreen(parentWindow));
        }

        /// <summary>
        /// Opens new window that contains the info about donations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Donate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.pushScreen(new DonateScreen(parentWindow));
        }

        /// <summary>
        /// Opens new window containing info about Corporate sponsers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CorporateSponsers_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.pushScreen(new CorporateScreen(parentWindow));
        }

        /// <summary>
        /// Opens new window containing info about Volunteers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Volunteers_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.pushScreen(new Volunteer(parentWindow));
        }
		
        /// <summary>
        /// Gets tweets from the CCF twitter feed (if there is internet connection)
        /// and writes them to a document to be opened and read to a RichTextBox
        /// </summary>
		private void GetTweets()
        {
            if (CheckInternetConnection())
            {
                TwitterFeed twit = new TwitterFeed();
                twit.updateTweets();
                List<List<string>> tweets = twit.GetTweets();

                Encoding utf8 = new UTF8Encoding(true);
                XmlTextWriter writer = new XmlTextWriter("../../Resources/events/events.xaml", utf8);
                writer.Formatting = Formatting.Indented;

                writer.WriteStartElement("FlowDocument");
                writer.WriteAttributeString("xmlns", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
                writer.WriteAttributeString("xmlns:x", "http://schemas.microsoft.com/winfx/2006/xaml");
                writer.WriteAttributeString("xmlns:s", "http://schemas.microsoft.com/surface/2008");
                writer.WriteAttributeString("TextAlignment", "Justify");
                writer.WriteStartElement("Section");
                foreach (List<string> t in tweets)
                {
                    writer.WriteStartElement("Paragraph");
                    //client.DownloadFile(new Uri(baseURI + imgsrc), filepath); 
                    foreach (string name in t)
                    {

                    }

                    writer.WriteStartElement("Line");
                    writer.WriteAttributeString("Stretch", "Fill");
                    writer.WriteAttributeString("Stroke", "Black");
                    writer.WriteAttributeString("X2", "1");
                    writer.WriteAttributeString("Margin", "-5");
                    writer.WriteEndElement(); // Line
                    writer.WriteEndElement(); // Paragraph
                }
            }
		}

        /// <summary>
        /// Pulls latest news from the CCF website (if connected to the internet)
        /// and writes them to a document to be opened and read to a RichTextBox. 
        /// Also downloads images used in each news item. Similar to getEvents()
        /// </summary>
        private void getNews()
        {
            if (CheckInternetConnection())
            {
                WebClient client = new WebClient(); // Creates a new WebClient which is used to grab data from sites
                String url;
                string excep = "";
                string target;
                string titlename;
                string when;
                string imgsrc;
                string desc;
                string filename;
                string filepath;

                // URL to the news page on the CCF website
                url = "http://www.childcancer.org.nz/News-and-events/News.aspx";
               
                try
                {
                    // Downloads the page (all the html code) into a buffer
                    byte[] myDataBuffer = client.DownloadData(url);
                    string result = System.Text.Encoding.UTF8.GetString(myDataBuffer);
                    
                    string baseURI = "http://www.childcancer.org.nz";

                    // A HTML document (from HtmlAgilityPack) that loads the 
                    // HTML string into the document.
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(result);

                    // Creates new UTF8 encoding
                    Encoding utf8 = new UTF8Encoding(true);

                    // Creates (overwrites if it already exists) a new .xaml file in the specified directory
                    // with the specified type of encoding
                    XmlTextWriter writer = new XmlTextWriter("../../Resources/news/news.xaml", utf8);
                    // Sets document to be neat and indented
                    writer.Formatting = Formatting.Indented;

                    // Writes to the document
                    writer.WriteStartElement("FlowDocument");
                    writer.WriteAttributeString("xmlns", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
                    writer.WriteAttributeString("xmlns:x", "http://schemas.microsoft.com/winfx/2006/xaml");
                    writer.WriteAttributeString("xmlns:s", "http://schemas.microsoft.com/surface/2008");
                    writer.WriteAttributeString("TextAlignment", "Justify");

                    // Creates a list of HTML nodes that are "div[class='item']", the item class is used 
                    // only for each news item and not anywhere else on the page. So guarantees that all 
                    // of the nodes contain news items. The wanted node is input as a XPath expression.
                    HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@class='item']");

                    // Loops through each node in the list
                    foreach (HtmlNode link in collection)
                    {
                        writer.WriteStartElement("Section");

                        writer.WriteStartElement("Paragraph");
                        writer.WriteAttributeString("FontSize", "20");
                        writer.WriteAttributeString("FontWeight", "Bold");
                        writer.WriteAttributeString("TextAlignment", "Center");

                        // XPath expression that gets the href attribute from the h3 node nested in the div item class
                        target = link.SelectSingleNode("h3//a").Attributes["href"].Value;

                        // Gets the text from within the h3 node
                        titlename = link.SelectSingleNode("h3//a").InnerText;

                        // Constructs the filename of the image
                        filename = target.Substring(target.LastIndexOf('/') + 1, target.LastIndexOf('.') - target.LastIndexOf('/') - 1);
                        writer.WriteStartElement("Underline");
                        writer.WriteString(titlename);
                        writer.WriteEndElement(); // Ends Underline node
                        writer.WriteEndElement(); // Ends Paragraph node

                        writer.WriteStartElement("Paragraph");
                        when = link.SelectSingleNode("small").InnerText;
                        writer.WriteString(when); // "When"
                        writer.WriteEndElement();

                        writer.WriteStartElement("BlockUIContainer");

                        // Latter part of link to where the news item image is stored on the website

                        imgsrc = link.SelectSingleNode("img").Attributes["src"].Value;

                        // Creates a filepath that the image will be downloaded to
                        filepath = "../../Resources/news/" + filename + ".jpeg";

                        // Downloads the file at the specified URL to the input filepath
                        // image source format: http://www.childcancer.org.nz/getattachment/0a92bafb-27d4-43c0-9d07-d8d5689bc1ad/Charity-Home-for-CCF.aspx
                        client.DownloadFile(new Uri(baseURI + imgsrc), filepath); 

                        // Dynamically gets the full directory location of where the image is stored locally which is used in the loading of the document
                        string basePath = AppDomain.CurrentDomain.BaseDirectory;
                        string commonPath = basePath.Remove(basePath.Length - @"bin\debug\".Length);
                        string fullfilepath = (commonPath + @"Resources\news\") + filename + ".jpeg";


                        writer.WriteStartElement("Image");
                        writer.WriteAttributeString("Source", fullfilepath);
                        writer.WriteEndElement(); // Image
                        writer.WriteEndElement(); // BlockUIContainer

                        writer.WriteStartElement("Paragraph");
                        desc = link.SelectSingleNode("p").InnerText;
                        writer.WriteString(desc);
                        writer.WriteEndElement(); // Paragraph

                        writer.WriteStartElement("Paragraph");
                        writer.WriteStartElement("Line");
                        writer.WriteAttributeString("Stretch", "Fill");
                        writer.WriteAttributeString("Stroke", "Black");
                        writer.WriteAttributeString("X2", "1");
                        writer.WriteAttributeString("Margin", "-5");
                        writer.WriteEndElement(); // Line
                        writer.WriteEndElement(); // Paragraph

                        writer.WriteEndElement(); // Paragraph
                    }

                    writer.WriteEndElement(); // FlowDocument
                    writer.Close();

                    // Creates a FlowDocument from the finished saved .xaml file
                    FlowDocument flowDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/news/news.xaml"));

                    // Passes the document into the RichTextBox which displays the formatted contents in the app
                    newsViewer.Document = flowDocument;

                }
                catch (Exception e)
                {
                    excep = e.ToString();
                }
                
            }
            else // No internet connection
            {
                // Reading from stored file
                FlowDocument flowDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/news/news.xaml"));

                newsViewer.Document = flowDocument;
            }

        }

        /// <summary>
        /// Pulls latest events from the CCF website (if connected to the internet)
        /// and writes them to a document to be opened and read to a RichTextBox. 
        /// Also downloads images used in each events item. Similar to getNews()
        /// </summary>
        private void GetEvents()
        {
            if (CheckInternetConnection())
            {
                WebClient client = new WebClient(); // Creates a new WebClient which is used to grab data from sites
                String url;
                string excep = "";
                string target;
                string titlename;
                string whenwhere;
                string imgsrc;
                string desc;
                string filename;
                string filepath;

                // URL to the events page on the CCF website
                url = "http://www.childcancer.org.nz/News-and-events/Events.aspx";

                
                try
                {
                    // Downloads the page (all the html code) into a buffer
                    byte[] myDataBuffer = client.DownloadData(url);
                    string result = System.Text.Encoding.UTF8.GetString(myDataBuffer);
                    string baseURI = "http://www.childcancer.org.nz";

                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(result);

                    Encoding utf8 = new UTF8Encoding(true);
                    XmlTextWriter writer = new XmlTextWriter("../../Resources/events/events.xaml", utf8);
                    writer.Formatting = Formatting.Indented;

                    writer.WriteStartElement("FlowDocument");
                    writer.WriteAttributeString("xmlns", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
                    writer.WriteAttributeString("xmlns:x", "http://schemas.microsoft.com/winfx/2006/xaml");
                    writer.WriteAttributeString("xmlns:s", "http://schemas.microsoft.com/surface/2008");
                    writer.WriteAttributeString("TextAlignment", "Justify");

                    // Creates a list of HTML nodes that are "div[class='item']", the item class is used 
                    // only for each news item and not anywhere else on the page. So guarantees that all 
                    // of the nodes contain news items. The wanted node is input as a XPath expression.
                    HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@class='item']");
                    foreach (HtmlNode link in collection)
                    {
                        writer.WriteStartElement("Section");

                        writer.WriteStartElement("Paragraph");
                        writer.WriteAttributeString("FontSize", "20");
                        writer.WriteAttributeString("FontWeight", "Bold");
                        writer.WriteAttributeString("TextAlignment", "Center");

                        target = link.SelectSingleNode("h3//a").Attributes["href"].Value;
                        titlename = link.SelectSingleNode("h3//a").InnerText;

                        filename = target.Substring(target.LastIndexOf('/') + 1, target.LastIndexOf('.') - target.LastIndexOf('/') - 1);
                        writer.WriteStartElement("Underline");
                        writer.WriteString(titlename);
                        writer.WriteEndElement(); // Underline
                        writer.WriteEndElement(); // Paragraph

                        writer.WriteStartElement("Paragraph");
                        
                        // Returned string format: "When:.....  CRLF Where:......."
                        whenwhere = link.SelectSingleNode("small").InnerText;

                        // Splits the returned string into 2 separate strings based on the CRLF which is equal to \r\n
                        string[] splitstring = whenwhere.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        writer.WriteString(splitstring[0]); // "When"
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteString(splitstring[1]); // "Where"
                        writer.WriteEndElement();

                        writer.WriteStartElement("BlockUIContainer");
                        imgsrc = link.SelectSingleNode("img").Attributes["src"].Value;

                        filepath = "../../Resources/events/" + filename + ".jpeg";

                        // Downloads the file at the specified URL to the input filepath
                        // image source format: http://www.childcancer.org.nz/getattachment/0a92bafb-27d4-43c0-9d07-d8d5689bc1ad/Charity-Home-for-CCF.aspx
                        client.DownloadFile(new Uri(baseURI + imgsrc), filepath); 

                        string basePath = AppDomain.CurrentDomain.BaseDirectory;
                        string commonPath = basePath.Remove(basePath.Length - @"bin\debug\".Length);
                        string fullfilepath = (commonPath + @"Resources\events\") + filename + ".jpeg";


                        writer.WriteStartElement("Image");
                        writer.WriteAttributeString("Source", fullfilepath);
                        writer.WriteEndElement(); // Image
                        writer.WriteEndElement(); // BlockUIContainer

                        writer.WriteStartElement("Paragraph");
                        desc = link.SelectSingleNode("p").InnerText;
                        writer.WriteString(desc);
                        writer.WriteEndElement(); // Paragraph

                        writer.WriteStartElement("Paragraph");
                        writer.WriteStartElement("Line");
                        writer.WriteAttributeString("Stretch", "Fill");
                        writer.WriteAttributeString("Stroke", "Black");
                        writer.WriteAttributeString("X2", "1");
                        writer.WriteAttributeString("Margin", "-5");
                        writer.WriteEndElement(); // Line
                        writer.WriteEndElement(); // Paragraph

                        writer.WriteEndElement(); // Paragraph
                    }

                    writer.WriteEndElement(); // FlowDocument
                    writer.Close();

                    FlowDocument flowDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/events/events.xaml"));

                    eventViewer.Document = flowDocument;

                }
                catch (Exception e)
                {
                    excep = e.ToString();
                }
            }
            else
            {
                // Reading from stored file
                FlowDocument flowDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/events/events.xaml"));

                eventViewer.Document = flowDocument;
            }

        }

        /// <summary>
        /// Checks the computer that the application is running from if there is internet connectivity. 
        /// </summary>
        /// <returns></returns>
        private bool CheckInternetConnection()
        {
            // Tries to establish a connection with Google (which doesn't go down), throws exception if it cannot connect
            // (which means there is no internet)
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}