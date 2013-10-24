using System.Windows.Media;
using System.Windows;
using System;
using System.Windows.Documents;
using System.Windows.Markup;
using System.IO;

namespace Team_Roasters.Screens
{
    /// <summary>
    /// Interaction logic for FamilySupportScreen.xaml
    /// </summary>
    public partial class Volunteer : Screen
    {
        /// <summary>
        /// Creating the Volunteer screen
        /// </summary>
        /// <param name="parentWindow"></param>
        public Volunteer(SurfaceWindow1 parentWindow)
            : base(parentWindow)
        {
            InitializeComponent();
            
            // Loads all the formatted douments into the program and assigns them to the appropriate FlowDocumentScrollViewers
            FlowDocument VolDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/docs/Volunteer/Volunteering.xaml"));
            VolViewer.Document = VolDocument;
            FlowDocument WhatIsVolDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/docs/Volunteer/WhatIsVolunteering.xaml"));
            WhatIsVolViewer.Document = WhatIsVolDocument;
            FlowDocument WhatWouldIDoDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/docs/Volunteer/WhatWouldIDo.xaml"));
            WhatWouldIDoViewer.Document = WhatWouldIDoDocument;
            FlowDocument WhoVolDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/docs/Volunteer/WhoCanVolunteer.xaml"));
            WhoVolViewer.Document = WhoVolDocument;

            WhatIsVolunteering.Visibility = System.Windows.Visibility.Visible;
            WhoCanVolunteer.Visibility = System.Windows.Visibility.Collapsed;
            WhatWouldIDo.Visibility = System.Windows.Visibility.Collapsed;
            Volunteering.Visibility = System.Windows.Visibility.Collapsed;
        }

        /// <summary>
        /// Returns to main screen upon touch of back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurfaceButton_Back(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
        }

        /// <summary>
        /// Moves to the Coporate Page on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Corperate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
            parentWindow.pushScreen(new CorporateScreen(parentWindow));
        }

        /// <summary>
        /// Moves to the Family & Support Page on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Family_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
            parentWindow.pushScreen(new FamilySupportScreen(parentWindow));
        }

        /// <summary>
        /// Moves to the What We Do Page on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void What_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
            parentWindow.pushScreen(new WhatWeDo(parentWindow));
        }

        /// <summary>
        /// Shows information about what volunteering is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurfaceButton_WhatIsVolunteering(object sender, System.Windows.RoutedEventArgs e)
        {
            WhatIsVolunteering.Visibility = System.Windows.Visibility.Visible;
            WhoCanVolunteer.Visibility = System.Windows.Visibility.Collapsed;
            WhatWouldIDo.Visibility = System.Windows.Visibility.Collapsed;
            Volunteering.Visibility = System.Windows.Visibility.Collapsed;
            WhatsIs_Button.Style = (Style)FindResource("SelectedButton");
            WhoCan_Button.Style = (Style)FindResource("NotSelectedButton");
            WhatDoIDo_Button.Style = (Style)FindResource("NotSelectedButton");
            CanI_Button.Style = (Style)FindResource("NotSelectedButton"); 
        }

        /// <summary>
        /// Displays the type of people that can volunteer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurfaceButton_WhoCanVolunteer(object sender, System.Windows.RoutedEventArgs e)
        {
            WhatIsVolunteering.Visibility = System.Windows.Visibility.Collapsed;
            WhoCanVolunteer.Visibility = System.Windows.Visibility.Visible;
            WhatWouldIDo.Visibility = System.Windows.Visibility.Collapsed;
            Volunteering.Visibility = System.Windows.Visibility.Collapsed;
            WhatsIs_Button.Style = (Style)FindResource("NotSelectedButton");
            WhoCan_Button.Style = (Style)FindResource("SelectedButton");
            WhatDoIDo_Button.Style = (Style)FindResource("NotSelectedButton");
            CanI_Button.Style = (Style)FindResource("NotSelectedButton");
        }

        /// <summary>
        /// Shows the types of things a volunteer would do
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurfaceButton_WhatWouldIDo(object sender, System.Windows.RoutedEventArgs e)
        {
            WhatIsVolunteering.Visibility = System.Windows.Visibility.Collapsed;
            WhoCanVolunteer.Visibility = System.Windows.Visibility.Collapsed;
            WhatWouldIDo.Visibility = System.Windows.Visibility.Visible;
            Volunteering.Visibility = System.Windows.Visibility.Collapsed;
            WhatsIs_Button.Style = (Style)FindResource("NotSelectedButton");
            WhoCan_Button.Style = (Style)FindResource("NotSelectedButton");
            WhatDoIDo_Button.Style = (Style)FindResource("SelectedButton");
            CanI_Button.Style = (Style)FindResource("NotSelectedButton");
        }

        /// <summary>
        /// Shows link and QR code to apply to be a volunteer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurfaceButton_Volunteering(object sender, System.Windows.RoutedEventArgs e)
        {
            WhatIsVolunteering.Visibility = System.Windows.Visibility.Collapsed;
            WhoCanVolunteer.Visibility = System.Windows.Visibility.Collapsed;
            WhatWouldIDo.Visibility = System.Windows.Visibility.Collapsed;
            Volunteering.Visibility = System.Windows.Visibility.Visible;
            WhatsIs_Button.Style = (Style)FindResource("NotSelectedButton");
            WhoCan_Button.Style = (Style)FindResource("NotSelectedButton");
            WhatDoIDo_Button.Style = (Style)FindResource("NotSelectedButton");
            CanI_Button.Style = (Style)FindResource("SelectedButton");
        }

        /// <summary>
        /// Sets the colours of on screen buttons
        /// </summary>
        public override void setButtonColours()
        {
            System.Windows.Media.BrushConverter bc = new System.Windows.Media.BrushConverter();
            App.Current.Resources["SelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FF69B4");
            App.Current.Resources["NotSelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FFFBA5D6");
        }

        /// <summary>
        /// This is called when the screen finishes its exiting animation.
        /// This ends up calling the same method in the parent class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Storyboard_Completed(object sender, EventArgs e)
        {
            parentWindow.Storyboard_Completed();
        }

        /// <summary>
        /// On entry, sets the colour of buttons to fit the colour scheme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Storyboard_Completed_1(object sender, EventArgs e)
        {
            setButtonColours();
        }
    }
}