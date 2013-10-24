using System.Windows.Media;
using System.Windows;
using Team_Roasters;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Markup;
using System.IO;
using System;

namespace Team_Roasters.Screens
{
    /// <summary>
    /// Interaction logic for DonateScreen.xaml
    /// </summary>
    public partial class DonateScreen : Screen
    {
        public DonateScreen(SurfaceWindow1 parentWindow) : base(parentWindow)
        {
            InitializeComponent();
            FlowDocument flowDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Donate/WhatYourMoneyBuys.xaml"));
            moneyBuysViewer.Document = flowDocument;
        }

        /// <summary>
        /// Called when the back button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurfaceButton_Back(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
        }

        /// <summary>
        /// Shows the Donation Content on Screen.
        /// This is where the QR code is found.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DonateNow_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DonateNow.Visibility = System.Windows.Visibility.Visible;
            WhatYourMoneyBuys.Visibility = System.Windows.Visibility.Collapsed;
            DonateNow_Button.Style = (Style)FindResource("SelectedButton");
            WhatYourMoneyBuys_Button.Style = (Style)FindResource("NotSelectedButton");
        }

        /// <summary>
        /// Shows the information about
        /// where donations are spent on screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WhatYourMoneyBuys_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DonateNow.Visibility = System.Windows.Visibility.Collapsed;
            WhatYourMoneyBuys.Visibility = System.Windows.Visibility.Visible;
            DonateNow_Button.Style = (Style)FindResource("NotSelectedButton");
            WhatYourMoneyBuys_Button.Style = (Style)FindResource("SelectedButton");
        }

        /// <summary>
        /// Sets the colours of the buttons to the correct colour scheme.
        /// </summary>
        public override void setButtonColours()
        {
            System.Windows.Media.BrushConverter bc = new System.Windows.Media.BrushConverter();
            App.Current.Resources["SelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FF15A6D2");
            App.Current.Resources["NotSelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FF8ECADC");
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

        private void Storyboard_Completed_1(object sender, EventArgs e)
        {
            setButtonColours();
        }
    }
}