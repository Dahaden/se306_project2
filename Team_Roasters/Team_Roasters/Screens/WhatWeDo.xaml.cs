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
        // Creates a FlowDocument from the finished saved .xaml file
        FlowDocument flowDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_AB.xaml"));
            
        public WhatWeDo(SurfaceWindow1 parentWindow) : base(parentWindow)
        {
            InitializeComponent();
            
            // Passes the document into the RichTextBox which displays the formatted contents in the app
            AB_text.Document = flowDocument;
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
            AB_text.Document = flowDocument;
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
            AB_text.Visibility = System.Windows.Visibility.Visible;
            BOK_text.Visibility = System.Windows.Visibility.Collapsed;
            LD_text.Visibility = System.Windows.Visibility.Collapsed;
            CJ_text.Visibility = System.Windows.Visibility.Collapsed;
            SP_text.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void Our_Amb_Enter_BOK(object sender, System.Windows.Input.TouchEventArgs e)
        {
            AB_text.Visibility = System.Windows.Visibility.Collapsed;
            BOK_text.Visibility = System.Windows.Visibility.Visible;
            LD_text.Visibility = System.Windows.Visibility.Collapsed;
            CJ_text.Visibility = System.Windows.Visibility.Collapsed;
            SP_text.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Our_Amb_Enter_CJ(object sender, System.Windows.Input.TouchEventArgs e)
        {
            AB_text.Visibility = System.Windows.Visibility.Collapsed;
            BOK_text.Visibility = System.Windows.Visibility.Collapsed;
            LD_text.Visibility = System.Windows.Visibility.Collapsed;
            CJ_text.Visibility = System.Windows.Visibility.Visible;
            SP_text.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Our_Amb_Enter_LD(object sender, System.Windows.Input.TouchEventArgs e)
        {
            AB_text.Visibility = System.Windows.Visibility.Collapsed;
            BOK_text.Visibility = System.Windows.Visibility.Collapsed;
            LD_text.Visibility = System.Windows.Visibility.Visible;
            CJ_text.Visibility = System.Windows.Visibility.Collapsed;
            SP_text.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Our_Amb_Enter_SP(object sender, System.Windows.Input.TouchEventArgs e)
        {
            AB_text.Visibility = System.Windows.Visibility.Collapsed;
            BOK_text.Visibility = System.Windows.Visibility.Collapsed;
            LD_text.Visibility = System.Windows.Visibility.Collapsed;
            CJ_text.Visibility = System.Windows.Visibility.Collapsed;
            SP_text.Visibility = System.Windows.Visibility.Visible;
        }

    }
}