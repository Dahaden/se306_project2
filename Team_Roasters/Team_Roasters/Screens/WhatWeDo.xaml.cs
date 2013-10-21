using Team_Roasters;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Markup;
using System.IO;
using System;
using HtmlAgilityPack;
using System.Text;
using System.Xml;
using System.Net;
namespace Team_Roasters.Screens
{
    /// <summary>
    /// Interaction logic for FamilySupportScreen.xaml
    /// </summary>
    public partial class WhatWeDo : Screen
    {
        // Creates a FlowDocuments for each Ambassador from the saved .xaml file
        FlowDocument Amb_AB = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_AB.xaml"));
        FlowDocument Amb_BOK = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_BOK.xaml"));
        FlowDocument Amb_CJ = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_CJ.xaml"));
        FlowDocument Amb_LD = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_LD.xaml"));
        FlowDocument Amb_SP = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_SP.xaml"));
            
        public WhatWeDo(SurfaceWindow1 parentWindow) : base(parentWindow)
        {
            InitializeComponent();
            
            // Passes the document into the RichTextBox which displays the formatted contents in the app
            Amb_text.Document = Amb_AB;
        }

        private void SurfaceButton_Back(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
        }

        private void SurfaceButton_OurAmbassadors(object sender, System.Windows.RoutedEventArgs e)
        {
            Our_Ambassadors.Visibility = System.Windows.Visibility.Visible;

            Our_People.Visibility = System.Windows.Visibility.Collapsed;
            Our_History.Visibility = System.Windows.Visibility.Collapsed;
            How_We_Help.Visibility = System.Windows.Visibility.Collapsed;

            // Passes the document into the RichTextBox which displays the formatted contents in the app
            Amb_text.Document = Amb_AB;
        }

        private void SurfaceButton_OurPeople(object sender, System.Windows.RoutedEventArgs e)
        {
            Our_Ambassadors.Visibility = System.Windows.Visibility.Collapsed;
            Our_People.Visibility = System.Windows.Visibility.Visible;
            Our_History.Visibility = System.Windows.Visibility.Collapsed;
            How_We_Help.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void SurfaceButton_OurHistory(object sender, System.Windows.RoutedEventArgs e)
        {
            Our_Ambassadors.Visibility = System.Windows.Visibility.Collapsed;
            Our_People.Visibility = System.Windows.Visibility.Collapsed;
            Our_History.Visibility = System.Windows.Visibility.Visible;
            How_We_Help.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void SurfaceButton_HowWeHelp(object sender, System.Windows.RoutedEventArgs e)
        {
            Our_Ambassadors.Visibility = System.Windows.Visibility.Collapsed;
            Our_People.Visibility = System.Windows.Visibility.Collapsed;
            Our_History.Visibility = System.Windows.Visibility.Collapsed;
            How_We_Help.Visibility = System.Windows.Visibility.Visible;
        }

        private void Our_Amb_Enter_AB(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Amb_text.Document = Amb_AB;
        }

        private void Our_Amb_Enter_BOK(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Amb_text.Document = Amb_BOK;
        }

        private void Our_Amb_Enter_CJ(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Amb_text.Document = Amb_CJ;
        }

        private void Our_Amb_Enter_LD(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Amb_text.Document = Amb_LD;
        }

        private void Our_Amb_Enter_SP(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Amb_text.Document = Amb_SP;
        }

    }
}