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
    public partial class FamilySupportScreen : Screen
    {
        /// <summary>
        /// Creating the Family Support screen
        /// </summary>
        /// <param name="parentWindow"></param>
        public FamilySupportScreen(SurfaceWindow1 parentWindow)
            : base(parentWindow)
        {
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

        /// <summary>
        /// Displays information about additional information available to families
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Moves to the Volunteers Page on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Volunteers_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
            parentWindow.pushScreen(new Volunteer(parentWindow));
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
        /// Displays information about holiday homes available to families
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Shows general information about the type of support CCF provides
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Shows information about what the scholarships are for and who they are for
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Sets the colours of on screen buttons
        /// </summary>
        public override void setButtonColours()
        {
            System.Windows.Media.BrushConverter bc = new System.Windows.Media.BrushConverter();
            App.Current.Resources["SelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FFCC33");
            App.Current.Resources["NotSelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FFFDC37D");
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
        /// Displays page of the draggable Beads and the information along with them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Mouse Down event for when user clicks on a blue bead. Displays description of blue bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void blueBead_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            bluedesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Touch Down event for when user touches on a blue bead. Displays description of blue bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void blueBead_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            bluedesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Mouse Down event for when user clicks on a orange bead. Displays description of orange bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orangeBead_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            browndesc.Visibility = Visibility.Hidden;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Touch Down event for when user touches on a brown bead. Displays description of brown bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void brownBead_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            browndesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Mouse Down event for when user clicks on a brown bead. Displays description of brown bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void brownBead_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            browndesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;

        }

        /// <summary>
        /// Touch Down event for when user touches on a orange bead. Displays description of orange bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orangeBead_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            browndesc.Visibility = Visibility.Hidden;
            whitedesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Visible;

        }

        /// <summary>
        /// Touch Down event for when user touches on a red bead. Displays description of red bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redBead_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            reddesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Mouse Down event for when user clicks on a red bead. Displays description of red bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redBead_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            reddesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Touch Down event for when user touches on a star bead. Displays description of star bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void starBead_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            stardesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Mouse Down event for when user clicks on a star bead. Displays description of star bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void starBead_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            stardesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Mouse Down event for when user clicks on a white bead. Displays description of white bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void whiteBead_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            whitedesc.Visibility = Visibility.Visible;
            bluedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Touch Down event for when user touches on a white bead. Displays description of white bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void whiteBead_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            whitedesc.Visibility = Visibility.Visible;
            bluedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Displays blue bead description when any type of input interacts with the white bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void whiteBead_MouseDown(object sender, System.Windows.RoutedEventArgs e)
        {
            whitedesc.Visibility = Visibility.Visible;
            bluedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Displays blue bead description when any type of input interacts with the blue bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void blueBead_ContainerActivated(object sender, System.Windows.RoutedEventArgs e)
        {
            bluedesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Displays blue bead description when any type of input interacts with the brown bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void brownBead_ContainerActivated(object sender, System.Windows.RoutedEventArgs e)
        {
            browndesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Displays blue bead description when any type of input interacts with the orange bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orangeBead_ContainerActivated(object sender, System.Windows.RoutedEventArgs e)
        {
            browndesc.Visibility = Visibility.Hidden;
            whitedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Displays blue bead description when any type of input interacts with the red bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redBead_ContainerActivated(object sender, System.Windows.RoutedEventArgs e)
        {
            reddesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            stardesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Displays blue bead description when any type of input interacts with the star bead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void starBead_ContainerActivated(object sender, System.Windows.RoutedEventArgs e)
        {
            stardesc.Visibility = Visibility.Visible;
            whitedesc.Visibility = Visibility.Hidden;
            bluedesc.Visibility = Visibility.Hidden;
            reddesc.Visibility = Visibility.Hidden;
            orangedesc.Visibility = Visibility.Hidden;
            browndesc.Visibility = Visibility.Hidden;
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