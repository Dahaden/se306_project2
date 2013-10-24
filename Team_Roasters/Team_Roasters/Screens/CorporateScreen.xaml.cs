﻿using System;
﻿using System.Windows;

namespace Team_Roasters.Screens
{
    /// <summary>
    /// Interaction logic for FamilySupportScreen.xaml
    /// </summary>
    public partial class CorporateScreen : Screen
    {
        public CorporateScreen(SurfaceWindow1 parentWindow)
            : base(parentWindow)
        {
            InitializeComponent();
        }

        private void SurfaceButton_Back(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
        }

        private void WhatWeDo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
            parentWindow.pushScreen(new WhatWeDo(parentWindow));
        }

        private void Volunteers_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
            parentWindow.pushScreen(new Volunteer(parentWindow));
        }

        private void Family_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
            parentWindow.pushScreen(new FamilySupportScreen(parentWindow));
        }

        public override void setButtonColours()
        {
            System.Windows.Media.BrushConverter bc = new System.Windows.Media.BrushConverter();
            App.Current.Resources["SelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FF68B9D2");
            App.Current.Resources["NotSelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FF68B9D2");
        }

        private void Touch_Down_Gold_Buyers(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Our_Ambassadors.Opacity = 0.5;
            GoldBuyers_popup.Visibility = Visibility.Visible;
        }  
		
		private void GoldBuyers_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	 Our_Ambassadors.Opacity = 0.5;
            GoldBuyers_popup.Visibility = Visibility.Visible;
        }

        private void Touch_Down_Farmers(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Our_Ambassadors.Opacity = 0.5;
            Farmers_popup.Visibility = Visibility.Visible;
        }
		
		private void Farmers_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	 Our_Ambassadors.Opacity = 0.5;
            Farmers_popup.Visibility = Visibility.Visible;
        }

        private void Touch_Down_RCP(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Our_Ambassadors.Opacity = 0.5;
            RCP_popup.Visibility = Visibility.Visible;        	
        }
		
		private void RCP_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	Our_Ambassadors.Opacity = 0.5;
            RCP_popup.Visibility = Visibility.Visible;
        } 

        private void Touch_Down_SaveMart(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Our_Ambassadors.Opacity = 0.5;
            SaveMart_popup.Visibility = Visibility.Visible;
        }
		
		private void SaveMart_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	Our_Ambassadors.Opacity = 0.5;
            SaveMart_popup.Visibility = Visibility.Visible;
        }   

        private void Touch_Down_Bartercard(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Our_Ambassadors.Opacity = 0.5;
            Bartercard_popup.Visibility = Visibility.Visible;
        }
		
		private void Bartercard_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	Our_Ambassadors.Opacity = 0.5;
            Bartercard_popup.Visibility = Visibility.Visible;
        }    

        private void ToolTipOpen(object sender, System.Windows.Controls.ToolTipEventArgs e)
        {
        	this.ToolTip = "Buzzy Bee and Friends";
        }

        private void Remove_popups(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Our_Ambassadors.Opacity = 1.0;
            GoldBuyers_popup.Visibility = Visibility.Collapsed;
            RCP_popup.Visibility = Visibility.Collapsed;
            Farmers_popup.Visibility = Visibility.Collapsed;
            Prof_popup.Visibility = Visibility.Collapsed;
            SaveMart_popup.Visibility = Visibility.Collapsed;
            Bartercard_popup.Visibility = Visibility.Collapsed;
        }

        private void Touch_Down_Prof(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Our_Ambassadors.Opacity = 0.5;
            Prof_popup.Visibility = Visibility.Visible;
        }
		
		private void Prof_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	Our_Ambassadors.Opacity = 0.5;
            Prof_popup.Visibility = Visibility.Visible;
        }    
        private void Remove_popups(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	Our_Ambassadors.Opacity = 1.0;
            GoldBuyers_popup.Visibility = Visibility.Collapsed;
            RCP_popup.Visibility = Visibility.Collapsed;
            Farmers_popup.Visibility = Visibility.Collapsed;
            Prof_popup.Visibility = Visibility.Collapsed;
            SaveMart_popup.Visibility = Visibility.Collapsed;
            Bartercard_popup.Visibility = Visibility.Collapsed;
        }

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