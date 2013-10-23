using System.Windows.Media;
using System.Windows;
namespace Team_Roasters.Screens
{
    /// <summary>
    /// Interaction logic for FamilySupportScreen.xaml
    /// </summary>
    public partial class FamilySupportScreen : Screen
    {
        public FamilySupportScreen(SurfaceWindow1 parentWindow) : base(parentWindow)
        {
            setButtonColours();
            InitializeComponent();

        }

        private void SurfaceButton_ParentResources(object sender, System.Windows.RoutedEventArgs e)
        {
            Parent_Resources.Visibility = System.Windows.Visibility.Visible;
            PR_Button.Style = (Style)FindResource("SelectedButton");
            Holiday_Homes.Visibility = System.Windows.Visibility.Collapsed;
            HH_Button.Style = (Style)FindResource("NotSelectedButton");
            Support_Services.Visibility = System.Windows.Visibility.Collapsed;
            SS_Button.Style = (Style)FindResource("NotSelectedButton");
            Scholarships.Visibility = System.Windows.Visibility.Collapsed;
            Scholarships_Button.Style = (Style)FindResource("NotSelectedButton");
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

        private void Volunteers_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
            parentWindow.pushScreen(new Volunteer(parentWindow));
        }

        private void What_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
            parentWindow.pushScreen(new WhatWeDo(parentWindow));
        }

        private void SurfaceButton_HolidayHomes(object sender, System.Windows.RoutedEventArgs e)
        {
            Holiday_Homes.Visibility = System.Windows.Visibility.Visible;
            PR_Button.Style = (Style)FindResource("NotSelectedButton");
            Parent_Resources.Visibility = System.Windows.Visibility.Collapsed;
            HH_Button.Style = (Style)FindResource("SelectedButton");
            Support_Services.Visibility = System.Windows.Visibility.Collapsed;
            SS_Button.Style = (Style)FindResource("NotSelectedButton");
            Scholarships.Visibility = System.Windows.Visibility.Collapsed;
            Scholarships_Button.Style = (Style)FindResource("NotSelectedButton");
        }

        private void SurfaceButton_SupportServices(object sender, System.Windows.RoutedEventArgs e)
        {
            Support_Services.Visibility = System.Windows.Visibility.Visible;
            PR_Button.Style = (Style)FindResource("NotSelectedButton");
            Holiday_Homes.Visibility = System.Windows.Visibility.Collapsed;
            HH_Button.Style = (Style)FindResource("NotSelectedButton");
            Parent_Resources.Visibility = System.Windows.Visibility.Collapsed;
            SS_Button.Style = (Style)FindResource("SelectedButton");
            Scholarships.Visibility = System.Windows.Visibility.Collapsed;
            Scholarships_Button.Style = (Style)FindResource("NotSelectedButton");
        }

        private void SurfaceButton_Scholarships(object sender, System.Windows.RoutedEventArgs e)
        {
            Scholarships.Visibility = System.Windows.Visibility.Visible;
            PR_Button.Style = (Style)FindResource("NotSelectedButton");
            Holiday_Homes.Visibility = System.Windows.Visibility.Collapsed;
            HH_Button.Style = (Style)FindResource("NotSelectedButton");
            Support_Services.Visibility = System.Windows.Visibility.Collapsed;
            SS_Button.Style = (Style)FindResource("NotSelectedButton");
            Parent_Resources.Visibility = System.Windows.Visibility.Collapsed;
            Scholarships_Button.Style = (Style)FindResource("SelectedButton");
        }

        private void setButtonColours()
        {
            System.Windows.Media.BrushConverter bc = new System.Windows.Media.BrushConverter();
            App.Current.Resources["SelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FFCC33");
            App.Current.Resources["NotSelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FFFDC37D");
        }
    }
}