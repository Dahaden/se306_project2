﻿using Team_Roasters;
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

        /// <summary>
        /// Creating the WhatWeDo screen
        /// </summary>
        /// <param name="parentWindow"></param>
        public WhatWeDo(SurfaceWindow1 parentWindow)
            : base(parentWindow)
        {
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

            // Loads the stored document files into the FlowDocumentScrollViewer
            FlowDocument flowDocument = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/docs/WhatWeDo/OurPeople.xaml"));
            ourPeopleViewer.Document = flowDocument;

            FlowDocument ourhistoryDoc = (FlowDocument)XamlReader.Load(File.OpenRead("../../Resources/docs/WhatWeDo/OurHistory.xaml"));
            ourHistoryViewer.Document = ourhistoryDoc;
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
        /// Shows the information about the amabassadors of CCF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Shows the information about people that work at CCF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Shows the history of the CCF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Shows the information about how CCF helps
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Switches to the next ambassador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SwitchNext()
        {
            Amb_counter++;
            if (Amb_counter >= images.Count)
            {
                Amb_counter = 0;
            }
            System.Windows.UIElement imageElement = (System.Windows.UIElement)images[Amb_counter];
            Amb_image.Children.RemoveAt(0);
            Amb_image.Children.Add(imageElement);

            Amb_text.Document = (FlowDocument)text[Amb_counter];
        }

        /// <summary>
        /// Switches to the previous ambassador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SwitchPrevious()
        {
            Amb_counter--;
            if (Amb_counter < 0)
            {
                Amb_counter = images.Count - 1;
            }
            System.Windows.UIElement imageElement = (System.Windows.UIElement)images[Amb_counter];
            Amb_image.Children.RemoveAt(0);
            Amb_image.Children.Add(imageElement);

            Amb_text.Document = (FlowDocument)text[Amb_counter];
        }

        /// <summary>
        /// Sets the colours of on screen buttons
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
        /// <summary>
        /// Touch up event for switching between ambassadors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_up(object sender, System.Windows.Input.TouchEventArgs e)
        {
            SwitchNext();
            System.Threading.Thread.Sleep(500);
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
        /// <summary>
        /// Mouse up event for switching between ambassadors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Our_Ambassadors_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SwitchNext();
            System.Threading.Thread.Sleep(500);
        }
    }
}