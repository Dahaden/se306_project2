using System.Windows.Documents;
using System.Windows.Markup;
using System.IO;
using System;
using HtmlAgilityPack;
using System.Text;
using System.Xml;
using System.Net;
using Team_Roasters;
using System.Collections.Generic;

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
            GetEvents();
        }

        private void What_we_do_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.pushScreen(new WhatWeDo(parentWindow));
        }

        private void FamilyButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.pushScreen(new FamilySupportScreen(parentWindow));
        }

        private void Donate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.pushScreen(new DonateScreen(parentWindow));
        }

        private void GetTweets()
        {
            if (CheckInternetConnection())
            {
                TwitterFeed twit = new TwitterFeed();
                twit.updateTweets();
                List<List<string>> tweets = twit.GetTweets();

            }
        }

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