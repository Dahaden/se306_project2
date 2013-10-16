using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;

using System.Collections.ObjectModel;

namespace Team_Roasters
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class Home_Page : SurfaceWindow
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Home_Page()
        {
            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        private void ccf_hidden_text_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ccf_close_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SurfaceButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void what_we_do_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FamilyButton_Click(object sender, RoutedEventArgs e)
        {
            Home.Visibility = System.Windows.Visibility.Collapsed;
            Family_Support.Visibility = System.Windows.Visibility.Visible;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataContext = this;
            pages.Add(Parent_Resources);
            pages.Add(Holiday_Homes);
            pages.Add(Support_Services);
            pages.Add(Scholarships);
        }

        private ObservableCollection<Grid> pages = new ObservableCollection<Grid>();

        private void SurfaceButton_ParentResources(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < pages.Count(); i++)
            {
                Grid page = pages.ElementAt(i);

                page.Visibility = System.Windows.Visibility.Collapsed;

                if (page.Equals(Parent_Resources))
                {
                    page.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void SurfaceButton_HolidayHomes(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < pages.Count(); i++)
            {
                Grid page = pages.ElementAt(i);

                page.Visibility = System.Windows.Visibility.Collapsed;

                if (page.Equals(Holiday_Homes))
                {
                    page.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void SurfaceButton_SupportServices(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < pages.Count(); i++)
            {
                Grid page = pages.ElementAt(i);

                page.Visibility = System.Windows.Visibility.Collapsed;

                if (page.Equals(Support_Services))
                {
                    page.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void SurfaceButton_Scholarships(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < pages.Count(); i++)
            {
                Grid page = pages.ElementAt(i);

                page.Visibility = System.Windows.Visibility.Collapsed;

                if (page.Equals(Scholarships))
                {
                    page.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void SurfaceButton_Back(object sender, RoutedEventArgs e)
        {
            Family_Support.Visibility = System.Windows.Visibility.Collapsed;
            Home.Visibility = System.Windows.Visibility.Visible;
        }


    }
}