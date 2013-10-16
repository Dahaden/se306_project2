using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Xml.Linq;
using System.Xml;
using System.Windows.Markup;

using System.Collections.ObjectModel;

namespace Team_Roasters
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class Home_Page : SurfaceWindow
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Home_Page()
        {
            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();

            GetEvents();

        }

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        private void ccf_hidden_text_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ccf_close_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SurfaceButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void what_we_do_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FamilyButton_Click(object sender, RoutedEventArgs e)
        {
            Home.Visibility = System.Windows.Visibility.Collapsed;
            Family_Support.Visibility = System.Windows.Visibility.Visible;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataContext = this;
            pages.Add(Parent_Resources);
            pages.Add(Holiday_Homes);
            pages.Add(Support_Services);
            pages.Add(Scholarships);
        }

        private ObservableCollection<Grid> pages = new ObservableCollection<Grid>();

        private void SurfaceButton_ParentResources(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < pages.Count(); i++)
            {
                Grid page = pages.ElementAt(i);

                page.Visibility = System.Windows.Visibility.Collapsed;

                if (page.Equals(Parent_Resources))
                {
                    page.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void SurfaceButton_HolidayHomes(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < pages.Count(); i++)
            {
                Grid page = pages.ElementAt(i);

                page.Visibility = System.Windows.Visibility.Collapsed;

                if (page.Equals(Holiday_Homes))
                {
                    page.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void SurfaceButton_SupportServices(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < pages.Count(); i++)
            {
                Grid page = pages.ElementAt(i);

                page.Visibility = System.Windows.Visibility.Collapsed;

                if (page.Equals(Support_Services))
                {
                    page.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void SurfaceButton_Scholarships(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < pages.Count(); i++)
            {
                Grid page = pages.ElementAt(i);

                page.Visibility = System.Windows.Visibility.Collapsed;

                if (page.Equals(Scholarships))
                {
                    page.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void SurfaceButton_Back(object sender, RoutedEventArgs e)
        {
            Family_Support.Visibility = System.Windows.Visibility.Collapsed;
            Home.Visibility = System.Windows.Visibility.Visible;
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