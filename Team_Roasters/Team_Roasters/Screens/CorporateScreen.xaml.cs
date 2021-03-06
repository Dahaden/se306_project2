﻿﻿using System;
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
            Remove_popups();
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
            Remove_popups();
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
            Remove_popups();
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
            Remove_popups();
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
            Remove_popups();
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
            Remove_popups();
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
            Remove_popups();
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
            Remove_popups();
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
            Remove_popups();
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
            Remove_popups();
            Our_Ambassadors.Opacity = 0.5;
            Bartercard_popup.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Displays information on Sponsor Professionals on Touch Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_Prof(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Remove_popups();
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
            Remove_popups();
            Our_Ambassadors.Opacity = 0.5;
            Prof_popup.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Collapses all 'popup' items on the screen on Touch events. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove_popups(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Remove_popups();
        }

        /// <summary>
        /// Collapses all 'popup' items on the screen on Mouse events. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove_popups(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Remove_popups();
        }

        /// <summary>
        /// Collapses all 'popup' items on the screen. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove_popups()
        {
            Our_Ambassadors.Opacity = 1.0;
            GoldBuyers_popup.Visibility = Visibility.Collapsed;
            Bartercard_popup.Visibility = Visibility.Collapsed;
            Farmers_popup.Visibility = Visibility.Collapsed;
            SaveMart_popup.Visibility = Visibility.Collapsed;
            RCP_popup.Visibility = Visibility.Collapsed;
            Prof_popup.Visibility = Visibility.Collapsed;
            BBnFreinds_text.Visibility = Visibility.Collapsed;
            _99_text.Visibility = Visibility.Collapsed;
            Alabar_text.Visibility = Visibility.Collapsed;
            The_Herald_text.Visibility = Visibility.Collapsed;
            Mill_text.Visibility = Visibility.Collapsed;
            Exposure_text.Visibility = Visibility.Collapsed;
            NZCouriers_text.Visibility = Visibility.Collapsed;
            Hansen_text.Visibility = Visibility.Collapsed;
            Bluebridge_text.Visibility = Visibility.Collapsed;
            Apparelmaster_text.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Displays information on Sponsor Buzzy Bees on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Mouse_down_BB(object sender, System.Windows.Input.MouseButtonEventArgs e){
            BB_popup();
		}

        /// <summary>
        /// Displays information on Sponsor Buzzy Bees on Touch Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Touch_Down_BB(object sender, System.Windows.Input.TouchEventArgs e){
            BB_popup();
        }

        /// <summary>
        /// Reveals the Buzzy Bee label popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BB_popup()
        {
            if (BBnFreinds_text.Visibility == Visibility.Collapsed)
            {
                Remove_popups();
                BBnFreinds_text.Visibility = Visibility.Visible;
            }
            else
            {
                BBnFreinds_text.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Displays information on Sponsor 99 on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Down_nn(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            nn_popup();
        }

        /// <summary>
        /// Displays information on Sponsor 99 on Touch Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_nn(object sender, System.Windows.Input.TouchEventArgs e)
        {
            nn_popup();
        }

        /// <summary>
        /// Reveals the 99 label popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nn_popup()
        {
            if (_99_text.Visibility == Visibility.Collapsed)
            {
                Remove_popups();
                _99_text.Visibility = Visibility.Visible;
            }
            else
            {
                _99_text.Visibility = Visibility.Collapsed;
            }
        }


        /// <summary>
        /// Displays information on Sponsor NZ Herald on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Down_NZHerald(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NZHerald_popup();
        }

        /// <summary>
        /// Displays information on Sponsor NZ Herald on Touch Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_NZHerald(object sender, System.Windows.Input.TouchEventArgs e)
        {
            NZHerald_popup();
        }

        /// <summary>
        /// Reveals the NZ Herald label popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NZHerald_popup()
        {
            if (The_Herald_text.Visibility == Visibility.Collapsed)
            {
                Remove_popups();
                The_Herald_text.Visibility = Visibility.Visible;
            }
            else
            {
                The_Herald_text.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Displays information on Sponsor The Millineum Hotel and Spas on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Down_Mill(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Mill_popup();
        }

        /// <summary>
        /// Displays information on Sponsor The Millineum Hotel and Spas on Touch Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_Mill(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Mill_popup();
        }

        /// <summary>
        /// Reveals the Millinium Hotel and Spas label popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mill_popup()
        {
            if (Mill_text.Visibility == Visibility.Collapsed)
            {
                Remove_popups();
                Mill_text.Visibility = Visibility.Visible;
            }
            else
            {
                Mill_text.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Displays information on Sponsor NZ Couriers on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Down_NZCouriers(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NZCouriers_popup();
        }

        /// <summary>
        /// Displays information on Sponsor NZ Couriers on Touch Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_NZCouriers(object sender, System.Windows.Input.TouchEventArgs e)
        {
            NZCouriers_popup();
        }

        /// <summary>
        /// Reveals the NZ Couriers label popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NZCouriers_popup()
        {
            if (NZCouriers_text.Visibility == Visibility.Collapsed)
            {
                Remove_popups();
                NZCouriers_text.Visibility = Visibility.Visible;
            }
            else
            {
                NZCouriers_text.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Displays information on Sponsor Exposure on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Down_Exposure(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Exposure_popup();
        }

        /// <summary>
        /// Displays information on Sponsor Exposure on Touch Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_Exposure(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Exposure_popup();
        }

        /// <summary>
        /// Reveals the Exposure label popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exposure_popup()
        {
            if (Exposure_text.Visibility == Visibility.Collapsed)
            {
                Remove_popups();
                Exposure_text.Visibility = Visibility.Visible;
            }
            else
            {
                Exposure_text.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Displays information on Sponsor Hansen on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Down_Hansen(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Hansen_popup();
        }

        /// <summary>
        /// Displays information on Sponsor Hansen on Touch Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_Hansen(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Hansen_popup();
        }

        /// <summary>
        /// Reveals the Hansen label popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hansen_popup()
        {
            if (Hansen_text.Visibility == Visibility.Collapsed)
            {
                Remove_popups();
                Hansen_text.Visibility = Visibility.Visible;
            }
            else
            {
                Hansen_text.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Displays information on Sponsor Apparel Master on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Down_ApparelMaster(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ApparelMaster_popup();
        }

        /// <summary>
        /// Displays information on Sponsor ApparelMaster on Touch Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_ApparelMaster(object sender, System.Windows.Input.TouchEventArgs e)
        {
            ApparelMaster_popup();
        }

        /// <summary>
        /// Reveals the ApparelMaster label popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApparelMaster_popup()
        {
            if (Apparelmaster_text.Visibility == Visibility.Collapsed)
            {
                Remove_popups();
                Apparelmaster_text.Visibility = Visibility.Visible;
            }
            else
            {
                Apparelmaster_text.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Displays information on Sponsor Alabar on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Down_Alabar(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Alabar_popup();
        }

        /// <summary>
        /// Displays information on Sponsor Alabar on Touch Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_Alabar(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Alabar_popup();
        }

        /// <summary>
        /// Reveals the Alabar label popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Alabar_popup()
        {
            if (Alabar_text.Visibility == Visibility.Collapsed)
            {
                Remove_popups();
                Alabar_text.Visibility = Visibility.Visible;
            }
            else
            {
                Alabar_text.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Displays information on Sponsor Bluebridge on Mouse Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Down_Bluebridge(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Bluebridge_popup();
        }

        /// <summary>
        /// Displays information on Sponsor Bluebridge on Touch Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Touch_Down_Bluebridge(object sender, System.Windows.Input.TouchEventArgs e)
        {
            Bluebridge_popup();
        }

        /// <summary>
        /// Reveals the Bluebridge label popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bluebridge_popup()
        {
            if (Bluebridge_text.Visibility == Visibility.Collapsed)
            {
                Remove_popups();
                Bluebridge_text.Visibility = Visibility.Visible;
            }
            else
            {
                Bluebridge_text.Visibility = Visibility.Collapsed;
            }
        }


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