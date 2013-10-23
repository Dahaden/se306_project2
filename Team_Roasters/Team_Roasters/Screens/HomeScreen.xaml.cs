using Team_Roasters;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using System;
using HtmlAgilityPack;
using System.Text;
using System.Xml;
using System.Net;
using System.Windows;
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
            GetTweets();
           
            // Position the scroller in the middle
            MainContent.ScrollToHorizontalOffset(950);

        }

        // Show the screensaver overlay
        public void showScreenSaver()
        {
            this.screensaver_overlay.Visibility = System.Windows.Visibility.Visible;
            this.screensaver_text.Visibility = System.Windows.Visibility.Visible;
        }

        // Hide the screensaver overlay
        public void hideScreenSaver()
        {
            this.screensaver_overlay.Visibility = System.Windows.Visibility.Collapsed;
            this.screensaver_text.Visibility = System.Windows.Visibility.Collapsed;
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
        /// and shows them on the main page
        /// </summary>
        private void GetTweets()
        {
            if (CheckInternetConnection())
            {
                WebClient client = new WebClient(); // Creates a new WebClient which is used to grab data from sites
                TwitterFeed twit = new TwitterFeed();
                string filename;
                string avatar_url;

                twit.updateTweets();
                List<List<string>> tweets = twit.GetTweets();
                for (int i = 0; i < tweets.Count; i++)
                {
                    //writer.WriteStartElement("Section");
                    // Tweet Info = {[name], [username], [avatar_url], [text], [timestamp]}
                    avatar_url = tweets[i][2];
                    filename = "../../Resources/twitter/" + avatar_url.Substring(avatar_url.LastIndexOf('/'));
                    if (!File.Exists(filename))  // Check if File is already there
                    {
                        client.DownloadFile(new Uri(avatar_url), filename);
                    }
                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                    string commonPath = basePath.Remove(basePath.Length - @"bin\debug\".Length);
                    string fullfilepath = (commonPath + @"Resources\twitter\") + filename.Substring(filename.LastIndexOf('/'));

                    var uri = new Uri(fullfilepath);
                    var bitmap = new BitmapImage(uri);

                    Image img = new Image();
                    img.Source = bitmap;
                    Grid.SetColumn(img, 0);
                    Grid.SetRow(img, i);
                    
                    RowDefinition rowDef = new RowDefinition();
                    twitterViewer.RowDefinitions.Add(rowDef);
                    
                    TextBlock userName = new TextBlock();
                    userName.FontWeight = FontWeights.Bold;
                    userName.FontSize = 23;
                    userName.Text = tweets[i][1];
                    Grid.SetRow(userName, 0);

                    TextBlock tweet = new TextBlock();
                    tweet.FontSize = 17;
                    tweet.Text = tweets[i][3];
                    tweet.TextWrapping = TextWrapping.Wrap;
                    Grid.SetRow(tweet, 1);

                    Grid inner = new Grid();

                    RowDefinition colDef1 = new RowDefinition();
                    RowDefinition colDef2 = new RowDefinition();
                    colDef1.Height = new GridLength(30);
                    inner.RowDefinitions.Add(colDef1);
                    inner.RowDefinitions.Add(colDef2);
                    Grid.SetColumn(inner, 1);
                    Grid.SetRow(inner, i);

                    inner.Children.Add(userName);
                    inner.Children.Add(tweet);

                    twitterViewer.Children.Add(img);
                    twitterViewer.Children.Add(inner);
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
                string imgsrc = "";
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

                    writer.WriteStartElement("FlowDocument.Resources");
                    writer.WriteStartElement("Style"); // This style is used to set the margins for all paragraphs in the FlowDocument to 0.
                    writer.WriteAttributeString("TargetType", "{x:Type Paragraph}");
                    writer.WriteStartElement("Setter");
                    writer.WriteAttributeString("Property", "Margin");
                    writer.WriteAttributeString("Value", "0");
                    writer.WriteEndElement(); // Setter
                    writer.WriteEndElement(); // Style
                    writer.WriteEndElement(); // FlowDocument.Resources

                    // Creates a list of HTML nodes that are "div[class='item']", the item class is used 
                    // only for each news item and not anywhere else on the page. So guarantees that all 
                    // of the nodes contain news items. The wanted node is input as a XPath expression.
                    HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@class='item']");

                    int count = 0; 

                    // Loops through each node in the list
                    foreach (HtmlNode link in collection)
                    {
                        writer.WriteStartElement("Section");
                        if (count % 2 == 0)
                        {
                            writer.WriteAttributeString("Background", "#FFDACFCF");
                        }
                        writer.WriteStartElement("Paragraph");
                        writer.WriteAttributeString("FontSize", "23");
                        writer.WriteAttributeString("FontWeight", "Bold");
                        writer.WriteAttributeString("TextAlignment", "Center");

                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();

                        // XPath expression that gets the href attribute from the h3 node nested in the div item class
                        target = link.SelectSingleNode("h3//a").Attributes["href"].Value;

                        // Gets the text from within the h3 node
                        titlename = link.SelectSingleNode("h3//a").InnerText;

                        // Constructs the filename of the image
                        filename = target.Substring(target.LastIndexOf('/') + 1, target.LastIndexOf('.') - target.LastIndexOf('/') - 1);
                        writer.WriteStartElement("Underline");
                        writer.WriteString(titlename);
                        writer.WriteEndElement(); // Ends Underline node
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteEndElement(); // Ends Paragraph node

                        writer.WriteStartElement("Paragraph");
                        writer.WriteAttributeString("FontSize", "17");
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        when = link.SelectSingleNode("small").InnerText;
                        writer.WriteString(when); // "When"
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        writer.WriteStartElement("BlockUIContainer");

                        // Latter part of link to where the news item image is stored on the website

                        try
                        {
                            imgsrc = link.SelectSingleNode("img").Attributes["src"].Value;
                        }
                        catch (Exception e)
                        {
                            // No image for this news item
                        }

                        // Creates a filepath that the image will be downloaded to
                        filepath = "../../Resources/news/" + filename + ".jpeg";

                        // Downloads the file at the specified URL to the input filepath
                        // image source format: http://www.childcancer.org.nz/getattachment/0a92bafb-27d4-43c0-9d07-d8d5689bc1ad/Charity-Home-for-CCF.aspx
                        if (!File.Exists(filepath)) // Doesn't re-download the file if it already exists. Saves time in execution
                        {
                            client.DownloadFile(new Uri(baseURI + imgsrc), filepath);
                        }
                        // Dynamically gets the full directory location of where the image is stored locally which is used in the loading of the document
                        string basePath = AppDomain.CurrentDomain.BaseDirectory;
                        string commonPath = basePath.Remove(basePath.Length - @"bin\debug\".Length);
                        string fullfilepath = (commonPath + @"Resources\news\") + filename + ".jpeg";


                        writer.WriteStartElement("Image");
                        writer.WriteAttributeString("Source", fullfilepath);
                        writer.WriteEndElement(); // Image
                        writer.WriteEndElement(); // BlockUIContainer

                        writer.WriteStartElement("Paragraph");
                        writer.WriteAttributeString("FontSize", "17");
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        desc = link.SelectSingleNode("p").InnerText;
                        writer.WriteString(desc);
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteEndElement(); // Paragraph

                        writer.WriteStartElement("Paragraph");
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteStartElement("Line");
                        writer.WriteAttributeString("Stretch", "Fill");
                        writer.WriteAttributeString("Stroke", "Black");
                        writer.WriteAttributeString("X2", "1");
                        writer.WriteAttributeString("StrokeThickness", "5");

                        writer.WriteEndElement(); // Line

                        writer.WriteEndElement(); // Paragraph

                        writer.WriteEndElement(); // Section

                        count++;
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
                //FlowDocument flowDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/news/news.xaml"));

                //newsViewer.Document = flowDocument;
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
                string imgsrc="";
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

                    writer.WriteStartElement("FlowDocument.Resources");
                    writer.WriteStartElement("Style"); // This style is used to set the margins for all paragraphs in the FlowDocument to 0.
                    writer.WriteAttributeString("TargetType", "{x:Type Paragraph}");
                    writer.WriteStartElement("Setter");
                    writer.WriteAttributeString("Property", "Margin");
                    writer.WriteAttributeString("Value", "0");
                    writer.WriteEndElement(); // Setter
                    writer.WriteEndElement(); // Style
                    writer.WriteEndElement(); // FlowDocument.Resources

                    // Creates a list of HTML nodes that are "div[class='item']", the item class is used 
                    // only for each news item and not anywhere else on the page. So guarantees that all 
                    // of the nodes contain news items. The wanted node is input as a XPath expression.
                    HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@class='item']");

                    int count = 0;
                    foreach (HtmlNode link in collection)
                    {
                        
                        writer.WriteStartElement("Section");
                        if (count % 2 == 0)
                        {
                            writer.WriteAttributeString("Background", "#FFDACFCF");
                        }
                        
                        writer.WriteStartElement("Paragraph");
                        writer.WriteAttributeString("FontSize", "23");
                        writer.WriteAttributeString("FontWeight", "Bold");
                        writer.WriteAttributeString("TextAlignment", "Center");

                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();

                        target = link.SelectSingleNode("h3//a").Attributes["href"].Value;
                        titlename = link.SelectSingleNode("h3//a").InnerText;

                        filename = target.Substring(target.LastIndexOf('/') + 1, target.LastIndexOf('.') - target.LastIndexOf('/') - 1);
                        writer.WriteStartElement("Underline");
                        writer.WriteString(titlename);
                        writer.WriteEndElement(); // Underline
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteEndElement(); // Paragraph

                        writer.WriteStartElement("Paragraph");
                        writer.WriteAttributeString("FontSize", "17");
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        // Returned string format: "When:.....  CRLF Where:......."
                        whenwhere = link.SelectSingleNode("small").InnerText;

                        // Splits the returned string into 2 separate strings based on the CRLF which is equal to \r\n
                        string[] splitstring = whenwhere.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        writer.WriteString(splitstring[0]); // "When"
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteString(splitstring[1]); // "Where"
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        writer.WriteStartElement("BlockUIContainer");

                        try
                        {
                            imgsrc = link.SelectSingleNode("img").Attributes["src"].Value;
                        }
                        catch (Exception e)
                        {
                            // No image for this news item
                        }

                        filepath = "../../Resources/events/" + filename + ".jpeg";

                        // Downloads the file at the specified URL to the input filepath
                        // image source format: http://www.childcancer.org.nz/getattachment/0a92bafb-27d4-43c0-9d07-d8d5689bc1ad/Charity-Home-for-CCF.aspx

                        if (!File.Exists(filepath)) // Doesn't re-download the file if it already exists. Saves time in execution
                        {
                            client.DownloadFile(new Uri(baseURI + imgsrc), filepath);
                        }
                        string basePath = AppDomain.CurrentDomain.BaseDirectory;
                        string commonPath = basePath.Remove(basePath.Length - @"bin\debug\".Length);
                        string fullfilepath = (commonPath + @"Resources\events\") + filename + ".jpeg";


                        writer.WriteStartElement("Image");
                        writer.WriteAttributeString("Source", fullfilepath);
                        writer.WriteEndElement(); // Image
                        writer.WriteEndElement(); // BlockUIContainer

                        writer.WriteStartElement("Paragraph");
                        writer.WriteAttributeString("FontSize", "17");
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        desc = link.SelectSingleNode("p").InnerText;
                        writer.WriteString(desc);
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteEndElement(); // Paragraph

                        writer.WriteStartElement("Paragraph");
                        writer.WriteStartElement("LineBreak");
                        writer.WriteEndElement();
                        writer.WriteStartElement("Line");
                        writer.WriteAttributeString("Stretch", "Fill");
                        writer.WriteAttributeString("Stroke", "Black");
                        writer.WriteAttributeString("X2", "1");
                        writer.WriteAttributeString("StrokeThickness", "5");
                        
                        writer.WriteEndElement(); // Line

                        writer.WriteEndElement(); // Paragraph

                        writer.WriteEndElement(); // Section

                        count++;
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

        /// <summary>
        /// Checks whether the side arrows should be shown/hidden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Scroll_changed(object sender, System.Windows.Controls.ScrollChangedEventArgs e)
        {
            if (MainContent.HorizontalOffset < 100)
            {
                Left_arrow.Visibility = Visibility.Collapsed;
                Left_arrow_block.Visibility = Visibility.Collapsed;
            }
            else
            {
                Left_arrow.Visibility = Visibility.Visible;
                Left_arrow_block.Visibility = Visibility.Visible;
            }
            if (MainContent.HorizontalOffset >= MainContent.ViewportWidth - 100)
            {
                Right_arrow.Visibility = Visibility.Collapsed;
                Right_arrow_block.Visibility = Visibility.Collapsed;
            }
            else
            {
                Right_arrow.Visibility = Visibility.Visible;
                Right_arrow_block.Visibility = Visibility.Visible;
            }
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            parentWindow.Storyboard_Completed();
        }   

        // Handle jump to left side of screen
        private void Left_arrow_block_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            MainContent.ScrollToLeftEnd();          
        }
        private void Left_arrow_block_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainContent.ScrollToLeftEnd();
        }

        // Handle jump to right side of screen
        private void Right_arrow_block_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            MainContent.ScrollToRightEnd();
        }
        private void Right_arrow_block_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainContent.ScrollToRightEnd();
        }


        private void FamilyButton_Click(object sender, System.Windows.Input.TouchEventArgs e)
        {
            parentWindow.pushScreen(new FamilySupportScreen(parentWindow));
        }

        private void What_we_do_Click(object sender, System.Windows.Input.TouchEventArgs e)
        {
            parentWindow.pushScreen(new WhatWeDo(parentWindow));
        }

        private void Volunteers_Click(object sender, System.Windows.Input.TouchEventArgs e)
        {
            parentWindow.pushScreen(new Volunteer(parentWindow));
        }

        private void CorporateSponsers_Click(object sender, System.Windows.Input.TouchEventArgs e)
        {
            parentWindow.pushScreen(new CorporateScreen(parentWindow));
        }

        public override void setButtonColours(){   }
    }
}