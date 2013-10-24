﻿using System;
﻿using System.Windows;

namespace Team_Roasters.Screens
{
    /// <summary>
    /// Interaction logic for CorporateScreen.xaml
    /// </summary>
    public partial class CorporateScreen : Screen
    {
        /// <summary>
        /// Creating the Corporate Screen
        /// </summary>
        /// <param name="SurfaceWindow1"></param>
        public CorporateScreen(SurfaceWindow1 parentWindow)
            : base(parentWindow)
        {
            InitializeComponent();
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
        /// Moves to the WhatWeDo Page on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WhatWeDo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
            parentWindow.pushScreen(new WhatWeDo(parentWindow));
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
        /// Moves to the Family&Support Page on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Family_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
            parentWindow.pushScreen(new FamilySupportScreen(parentWindow));
        }

        /// <summary>
        /// Sets the colours of on screen buttons
        /// </summary>
        public override void setButtonColours()
        {
            System.Windows.Media.BrushConverter bc = new System.Windows.Media.BrushConverter();
            App.Current.Resources["SelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FF68B9D2");
            App.Current.Resources["NotSelectedColour"] = (System.Windows.Media.Brush)bc.ConvertFrom("#FF68B9D2");
        }

        /// <summary>
        /// Displays information on Sponsor Gold Buyers on touch event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_Gold_Buyers(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Our_Ambassadors.Opacity = 0.5;
            GoldBuyers_popup.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Displays information on Sponsor Gold Buyers on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void GoldBuyers_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	 Our_Ambassadors.Opacity = 0.5;
            GoldBuyers_popup.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Displays information on Sponsor Farmers on touch event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_Farmers(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Our_Ambassadors.Opacity = 0.5;
            Farmers_popup.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Displays information on Sponsor Farmers on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Farmers_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	 Our_Ambassadors.Opacity = 0.5;
            Farmers_popup.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Displays information on Sponsor RCP on touch event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_RCP(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Our_Ambassadors.Opacity = 0.5;
            RCP_popup.Visibility = Visibility.Visible;        	
        }

        /// <summary>
        /// Displays information on Sponsor Gold Buyers on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void RCP_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	Our_Ambassadors.Opacity = 0.5;
            RCP_popup.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Displays information on Sponsor SaveMart on touch event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_SaveMart(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Our_Ambassadors.Opacity = 0.5;
            SaveMart_popup.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Displays information on Sponsor SaveMart on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void SaveMart_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	Our_Ambassadors.Opacity = 0.5;
            SaveMart_popup.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Displays information on Sponsor BarterCard on touch event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_Bartercard(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Our_Ambassadors.Opacity = 0.5;
            Bartercard_popup.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Displays information on Sponsor Bartercard on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Bartercard_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	Our_Ambassadors.Opacity = 0.5;
            Bartercard_popup.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creates an Overlay over Buzzy Bee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolTipOpen(object sender, System.Windows.Controls.ToolTipEventArgs e)
        {
        	this.ToolTip = "Buzzy Bee and Friends";
        }

        /// <summary>
        /// Displays information on Sponsor Prof on Touch Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_Prof(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Our_Ambassadors.Opacity = 0.5;
            Prof_popup.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Displays information on Sponsor Prof on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Prof_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	Our_Ambassadors.Opacity = 0.5;
            Prof_popup.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Restores page to original State on mouse event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Restores page to original State on touch event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Informs the parent window that it has left the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Storyboard_Completed(object sender, EventArgs e)
        {
            parentWindow.Storyboard_Completed();
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