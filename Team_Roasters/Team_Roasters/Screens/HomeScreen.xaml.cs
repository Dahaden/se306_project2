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
            getContent("events");
            // getContent("news");
        }

        private void what_we_do_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void FamilyButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.pushScreen(new FamilySupportScreen(parentWindow));
        }

        private void getContent(String contentType) {
            if (CheckInternetConnection()) {
                WebClient client = new WebClient();
                String url = "";
                Encoding utf8 = new UTF8Encoding(true);
                XmlTextWriter writer;
                FlowDocument flowDocument;
                System.Console.Write("Here yay");
                switch (contentType) { 
                    case "events":
                        url = "http://www.childcancer.org.nz/News-and-events/Events.aspx";
                        writer = new XmlTextWriter("../../Resources/events/events.xaml", utf8);
                        flowDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/events/events.xaml"));
                        break;
                    case "news":
                        url = "http://www.childcancer.org.nz/News-and-events/News.aspx";
                        writer = new XmlTextWriter("../../Resources/news/news.xaml", utf8);
                        flowDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/news/news.xaml"));
                        break;
                    default:
                        // this case should never be hit
                        writer = new XmlTextWriter("", utf8);
                        flowDocument = new FlowDocument();
                        break;
                }

                string excep = "";
                try {
                    byte[] myDataBuffer = client.DownloadData(url);
                    string result = System.Text.Encoding.UTF8.GetString(myDataBuffer);

                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(result);
                    writer.Formatting = Formatting.Indented;

                    writer.WriteStartElement("FlowDocument");
                    writer.WriteAttributeString("xmlns", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
                    writer.WriteAttributeString("xmlns:x", "http://schemas.microsoft.com/winfx/2006/xaml");
                    writer.WriteAttributeString("xmlns:s", "http://schemas.microsoft.com/surface/2008");
                    writer.WriteAttributeString("TextAlignment", "Justify");

                    HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@class='item']");
                    foreach (HtmlNode link in collection) {
                        writeStuff(writer, link, contentType);
                    }
                    writer.WriteEndElement(); // FlowDocument
                    writer.Close();
                    eventViewer.Document = flowDocument;
                }
                catch (Exception e) {
                    excep = e.ToString();
                }
                // Event image source format: http://www.childcancer.org.nz/getattachment/0a92bafb-27d4-43c0-9d07-d8d5689bc1ad/Charity-Home-for-CCF.aspx
            } else {
                // Reading from stored file
                FlowDocument flowDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/news/news.xaml"));
                eventViewer.Document = flowDocument;
            }
        }

        private void writeStuff(XmlTextWriter writer, HtmlNode link, String contentType) {
            string target, titlename, whenwhere, imgsrc, desc, filename, filepath;

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
            whenwhere = link.SelectSingleNode("small").InnerText;

            string[] splitstring = whenwhere.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            writer.WriteString(splitstring[0]); // "When"
            writer.WriteStartElement("LineBreak");
            writer.WriteEndElement();
            writer.WriteString(splitstring[1]); // "Where"
            writer.WriteEndElement();

            writer.WriteStartElement("BlockUIContainer");
            imgsrc = link.SelectSingleNode("img").Attributes["src"].Value;

            filepath = "../../Resources/news/" + filename + ".jpeg";

            // Uncomment below line to download the images. Otherwise it will download images each run
            // client.DownloadFile(new Uri(baseURI + imgsrc), filepath); 

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
/*
        private void GetEvents()
        {
            if (CheckInternetConnection())
            {
                WebClient client = new WebClient();
                String url;
                string excep = "";
                string target;
                string titlename;
                string whenwhere;
                string imgsrc;
                string desc;
                string filename;

                url = "http://www.childcancer.org.nz/News-and-events/Events.aspx";

                string filepath;
                try
                {

                    byte[] myDataBuffer = client.DownloadData(url);
                    string result = System.Text.Encoding.UTF8.GetString(myDataBuffer);
                    //string baseURI = "http://www.childcancer.org.nz";

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
                        whenwhere = link.SelectSingleNode("small").InnerText;

                        string[] splitstring = whenwhere.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        writer.WriteString(splitstring[0]); // "When"
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteString(splitstring[1]); // "Where"
                        writer.WriteEndElement();

                        writer.WriteStartElement("BlockUIContainer");
                        imgsrc = link.SelectSingleNode("img").Attributes["src"].Value;

                        filepath = "../../Resources/events/" + filename + ".jpeg";

                        // Uncomment below line to download the images. Otherwise it will download images each run
                        // client.DownloadFile(new Uri(baseURI + imgsrc), filepath); 

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
                // Event image source format: http://www.childcancer.org.nz/getattachment/0a92bafb-27d4-43c0-9d07-d8d5689bc1ad/Charity-Home-for-CCF.aspx
            }
            else
            {
                // Reading from stored file
                FlowDocument flowDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/events/events.xaml"));

                eventViewer.Document = flowDocument;
            }

        }
*/



        private bool CheckInternetConnection()
        {
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