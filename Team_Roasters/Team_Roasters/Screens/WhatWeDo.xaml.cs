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
using System.Collections;
using System.Windows;
﻿using System.Windows.Media;
namespace Team_Roasters.Screens
{
    /// <summary>
    /// Interaction logic for FamilySupportScreen.xaml
    /// </summary>
    public partial class WhatWeDo : Screen
    {
       
        int Amb_counter = 0;
        ArrayList images = new ArrayList();
        ArrayList text = new ArrayList();
       
        public WhatWeDo(SurfaceWindow1 parentWindow) : base(parentWindow)
        {
            setButtonColours();
            InitializeComponent();

            AB_image ABimage = new AB_image();
            BOK_image BOKimage = new BOK_image();
            CJ_image CJimage = new CJ_image();
            LD_image LDimage = new LD_image();
            SP_image SPimage = new SP_image();
            EMHB_image EMHBimage = new EMHB_image();
            JK_image JKimage = new JK_image();
            KR_image KRimage = new KR_image();
            MA_image MAimage = new MA_image();

            images.Add(ABimage);
            images.Add(BOKimage);
            images.Add(CJimage);
            images.Add(LDimage);
            images.Add(SPimage);
            images.Add(EMHBimage);
            images.Add(JKimage);
            images.Add(KRimage);
            images.Add(MAimage);

            // Creates a FlowDocuments for each Ambassador from the saved .xaml file
            FlowDocument Amb_AB = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_AB.xaml"));
            FlowDocument Amb_BOK = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_BOK.xaml"));
            FlowDocument Amb_CJ = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_CJ.xaml"));
            FlowDocument Amb_LD = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_LD.xaml"));
            FlowDocument Amb_SP = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_SP.xaml"));
            FlowDocument Amb_EMHB = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_EMHB.xaml"));
            FlowDocument Amb_JK = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_JK.xaml"));
            FlowDocument Amb_KR = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_KR.xaml"));
            FlowDocument Amb_MA = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/Ambassadors/Amb_MA.xaml"));

            text.Add(Amb_AB);
            text.Add(Amb_BOK);
            text.Add(Amb_CJ);
            text.Add(Amb_LD);
            text.Add(Amb_SP);
            text.Add(Amb_EMHB);
            text.Add(Amb_JK);
            text.Add(Amb_KR);
            text.Add(Amb_MA);

            Amb_image.Children.Add(ABimage);
            Amb_text.Document = Amb_AB;
            
        }

        private void SurfaceButton_Back(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
        }

        private void SurfaceButton_OurAmbassadors(object sender, System.Windows.RoutedEventArgs e)
        {
            Our_Ambassadors.Visibility = System.Windows.Visibility.Visible;
            Ambassador_Button.Style = (Style)FindResource("SelectedButton");
            Our_People.Visibility = System.Windows.Visibility.Collapsed;
            People_Button.Style = (Style)FindResource("NotSelectedButton");
            Our_History.Visibility = System.Windows.Visibility.Collapsed;
            History_Button.Style = (Style)FindResource("NotSelectedButton");
            How_We_Help.Visibility = System.Windows.Visibility.Collapsed;
            Help_Button.Style = (Style)FindResource("NotSelectedButton");
        }

        private void SurfaceButton_OurPeople(object sender, System.Windows.RoutedEventArgs e)
        {
            Our_Ambassadors.Visibility = System.Windows.Visibility.Collapsed;
            Ambassador_Button.Style = (Style)FindResource("NotSelectedButton");
            Our_People.Visibility = System.Windows.Visibility.Visible;
            People_Button.Style = (Style)FindResource("SelectedButton");
            Our_History.Visibility = System.Windows.Visibility.Collapsed;
            History_Button.Style = (Style)FindResource("NotSelectedButton");
            How_We_Help.Visibility = System.Windows.Visibility.Collapsed;
            Help_Button.Style = (Style)FindResource("NotSelectedButton");
        }

        private void SurfaceButton_OurHistory(object sender, System.Windows.RoutedEventArgs e)
        {
            Our_Ambassadors.Visibility = System.Windows.Visibility.Collapsed;
            Ambassador_Button.Style = (Style)FindResource("NotSelectedButton");
            Our_People.Visibility = System.Windows.Visibility.Collapsed;
            People_Button.Style = (Style)FindResource("NotSelectedButton");
            Our_History.Visibility = System.Windows.Visibility.Visible;
            History_Button.Style = (Style)FindResource("SelectedButton");
            How_We_Help.Visibility = System.Windows.Visibility.Collapsed;
            Help_Button.Style = (Style)FindResource("NotSelectedButton");
        }

        private void SurfaceButton_HowWeHelp(object sender, RoutedEventArgs e)
        {
            Our_Ambassadors.Visibility = System.Windows.Visibility.Collapsed;
            Ambassador_Button.Style = (Style)FindResource("NotSelectedButton");
            Our_People.Visibility = System.Windows.Visibility.Collapsed;
            People_Button.Style = (Style)FindResource("NotSelectedButton");
            Our_History.Visibility = System.Windows.Visibility.Collapsed;
            History_Button.Style = (Style)FindResource("NotSelectedButton");
            How_We_Help.Visibility = System.Windows.Visibility.Visible;
            Help_Button.Style = (Style)FindResource("SelectedButton");
        }

          
        private void Touch_enter(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Amb_image.Opacity = 0.25;
            Amb_text.Opacity = 0.25;
        }

        private void Touch_leave(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Amb_image.Opacity = 1.0;
            Amb_text.Opacity = 1.0;

            System.Windows.UIElement imageElement = (System.Windows.UIElement)images[Amb_counter];
            Amb_image.Children.RemoveAt(0);
            Amb_image.Children.Add(imageElement);

            Amb_text.Document = (FlowDocument)text[Amb_counter];
            
            Amb_counter++;
            if (Amb_counter >= images.Count)
            {
                Amb_counter = 0;
            }
            System.Threading.Thread.Sleep(500); //TODO - get rid of sleep but still have it that it doesn't click through to the next one straight away
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