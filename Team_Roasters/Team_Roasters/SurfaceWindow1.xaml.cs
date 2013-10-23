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
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Xml.Linq;
using System.Xml;
using System.Windows.Markup;

using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.ComponentModel;
using System.Diagnostics;

namespace Team_Roasters
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        private Stack<Screen> screenStack;

        private DispatcherTimer inactivityTimer = new DispatcherTimer();
        private int inactiveTime = 0;
        private bool screensaver = true;

        const int TIMEOUT_TIME = 600;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();

            // Create the stack of screens, and push the home screen on to start with.
            screenStack = new Stack<Screen>();
            pushScreen(new Screens.HomeScreen(this));

            inactivityTimer.Interval = TimeSpan.FromSeconds(1);
            inactivityTimer.Tick += new EventHandler(checkInactivity);
            inactivityTimer.Start();
        }

        public void checkInactivity(Object sender, EventArgs e)
        {
            if (inactiveTime > TIMEOUT_TIME)
            {
                popAll();
                ((Screens.HomeScreen)screenStack.Peek()).showScreenSaver();
                this.screensaver = true;
            }
            this.inactiveTime++;
        }

        /// <summary>
        /// Remove the top screen from the stack
        /// Display the next screen
        /// </summary>
        public void popScreen()
        {
            if (screenStack.Count > 1)
            {
                screenStack.Pop();
                this.Content = screenStack.Peek();
                this.WindowState = WindowState.Maximized;
                this.WindowStyle = WindowStyle.None;
            }
        }

        /// <summary>
        /// Add a screen to the stack and display it
        /// </summary>
        public void pushScreen(Screen screen)
        {
            screenStack.Push(screen);
            this.Content = screenStack.Peek();
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;

        }

        /// <summary>
        /// Display the first screen on the stack
        /// Useful for 'return to home' functionality
        /// </summary>
        public void popAll()
        {
            while (screenStack.Count > 1)
            {
                screenStack.Pop();
            }
            this.Content = screenStack.Peek();
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;
        }

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

        private void activityEvent(object sender, MouseButtonEventArgs e)
        {
            inactiveTime = 0;
            if (screensaver)
            {
                ((Screens.HomeScreen)screenStack.Peek()).hideScreenSaver();
                screensaver = false;
            }

        }
    }
}