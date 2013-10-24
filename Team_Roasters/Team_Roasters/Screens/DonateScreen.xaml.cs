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
    /// Interaction logic for FamilySupportScreen.xaml
    /// </summary>
    public partial class DonateScreen : Screen
    {
        public DonateScreen(SurfaceWindow1 parentWindow) : base(parentWindow)
        {
            InitializeComponent();
            setButtonColours();
            FlowDocument flowDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Donate/WhatYourMoneyBuys.xaml"));
            moneyBuysViewer.Document = flowDocument;
        }

        private void SurfaceButton_Back(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
        }

        private void DonateNow_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DonateNow.Visibility = System.Windows.Visibility.Visible;
            WhatYourMoneyBuys.Visibility = System.Windows.Visibility.Collapsed;
            DonateNow_Button.Style = (Style)FindResource("SelectedButton");
            WhatYourMoneyBuys_Button.Style = (Style)FindResource("NotSelectedButton");
        }

        private void WhatYourMoneyBuys_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DonateNow.Visibility = System.Windows.Visibility.Collapsed;
            WhatYourMoneyBuys.Visibility = System.Windows.Visibility.Visible;
            DonateNow_Button.Style = (Style)FindResource("NotSelectedButton");
            WhatYourMoneyBuys_Button.Style = (Style)FindResource("SelectedButton");
        }

        private void setButtonColours()
        {
            System.Windows.Media.BrushConverter bc = new System.Windows.Media.BrushConverter();
            App.Current.Resources["SelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FF68B9D2");
            App.Current.Resources["NotSelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FF8ECADC");
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            parentWindow.Storyboard_Completed();
        }
    }
}