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
    public partial class FamilySupportScreen : Screen
    {
        public FamilySupportScreen(SurfaceWindow1 parentWindow)
            : base(parentWindow)
        {
            setButtonColours();
            InitializeComponent();

            FlowDocument HoldiayHomesDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/docs/FamilySupport/HolidayHomes.xaml"));
            HolidayHomesViewer.Document = HoldiayHomesDocument;
            FlowDocument ParentResourcesDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/docs/FamilySupport/ParentResources.xaml"));
            ParentResourcesViewer.Document = ParentResourcesDocument;
            FlowDocument ScholarshipsDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/docs/FamilySupport/Scholarships.xaml"));
            ScholarshipsViewer.Document = ScholarshipsDocument;
            FlowDocument SupportServicesDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/docs/FamilySupport/SupportServices.xaml"));
            SupportServicesViewer.Document = SupportServicesDocument;
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
            Beads.Visibility = Visibility.Collapsed;
            Beads_Button.Style = (Style)FindResource("NotSelectedButton");

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
            Beads.Visibility = Visibility.Collapsed;
            Beads_Button.Style = (Style)FindResource("NotSelectedButton");
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
            Beads.Visibility = Visibility.Collapsed;
            Beads_Button.Style = (Style)FindResource("NotSelectedButton");
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
            Beads.Visibility = Visibility.Collapsed;
            Beads_Button.Style = (Style)FindResource("NotSelectedButton");
        }

        private void setButtonColours()
        {
            System.Windows.Media.BrushConverter bc = new System.Windows.Media.BrushConverter();
            App.Current.Resources["SelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FFCC33");
            App.Current.Resources["NotSelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FFFDC37D");
        }

        private void SurfaceButton_Beads(object sender, System.Windows.RoutedEventArgs e)
        {
            Scholarships.Visibility = System.Windows.Visibility.Collapsed;
            PR_Button.Style = (Style)FindResource("NotSelectedButton");
            Holiday_Homes.Visibility = System.Windows.Visibility.Collapsed;
            HH_Button.Style = (Style)FindResource("NotSelectedButton");
            Support_Services.Visibility = System.Windows.Visibility.Collapsed;
            SS_Button.Style = (Style)FindResource("NotSelectedButton");
            Parent_Resources.Visibility = System.Windows.Visibility.Collapsed;
            Scholarships_Button.Style = (Style)FindResource("NotSelectedButton");
            Beads.Visibility = Visibility.Visible;
            Beads_Button.Style = (Style)FindResource("SelectedButton");
            stardesc.Visibility = Visibility.Hidden;
            whitedesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;

        }

        private void blueBead_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            bluedesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        private void blueBead_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            bluedesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        private void orangeBead_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            browndesc.Visibility = Visibility.Hidden;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Visible;
        }

        private void brownBead_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            browndesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
        }

        private void brownBead_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            browndesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;

        }

        private void orangeBead_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            browndesc.Visibility = Visibility.Hidden;
            whitedesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Visible;

        }

        private void redBead_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            reddesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        private void redBead_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            reddesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        private void starBead_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            stardesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        private void starBead_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            stardesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        private void whiteBead_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            whitedesc.Visibility = Visibility.Visible;
            bluedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        private void whiteBead_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            whitedesc.Visibility = Visibility.Visible;
            bluedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        private void whiteBead_MouseDown(object sender, System.Windows.RoutedEventArgs e)
        {
            whitedesc.Visibility = Visibility.Visible;
            bluedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        private void blueBead_ContainerActivated(object sender, System.Windows.RoutedEventArgs e)
        {
            bluedesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        private void brownBead_ContainerActivated(object sender, System.Windows.RoutedEventArgs e)
        {
            browndesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
        }

        private void orangeBead_ContainerActivated(object sender, System.Windows.RoutedEventArgs e)
        {
            browndesc.Visibility = Visibility.Hidden;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Visible;
        }

        private void redBead_ContainerActivated(object sender, System.Windows.RoutedEventArgs e)
        {
            reddesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        private void starBead_ContainerActivated(object sender, System.Windows.RoutedEventArgs e)
        {
            stardesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }


    }
}