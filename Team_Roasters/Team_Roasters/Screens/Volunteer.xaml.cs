using System.Windows.Media;
using System.Windows;
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
        public Volunteer(SurfaceWindow1 parentWindow) : base(parentWindow)
        {
            setButtonColours();
            InitializeComponent();

            FlowDocument VolDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/docs/Volunteer/Volunteering.xaml"));
            VolViewer.Document = VolDocument;
            FlowDocument WhatIsVolDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/docs/Volunteer/WhatIsVolunteering.xaml"));
            WhatIsVolViewer.Document = WhatIsVolDocument;
            FlowDocument WhatWouldIDoDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/docs/Volunteer/WhatWouldIDo.xaml"));
            WhatWouldIDoViewer.Document = WhatWouldIDoDocument;
            FlowDocument WhoVolDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/docs/Volunteer/WhoCanVolunteer.xaml"));
            WhoVolViewer.Document = WhoVolDocument;
        }

        private void SurfaceButton_Back(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
        }

        private void Corperate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
            parentWindow.pushScreen(new CorporateScreen(parentWindow));
        }

        private void Family_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
            parentWindow.pushScreen(new FamilySupportScreen(parentWindow));
        }

        private void What_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
            parentWindow.pushScreen(new WhatWeDo(parentWindow));
        }

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

        private void setButtonColours()
        {
            System.Windows.Media.BrushConverter bc = new System.Windows.Media.BrushConverter();
            App.Current.Resources["SelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FF69B4");
            App.Current.Resources["NotSelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FFFBA5D6");
        }
    }
}