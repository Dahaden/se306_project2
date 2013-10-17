namespace Team_Roasters.Screens
{
    /// <summary>
    /// Interaction logic for FamilySupportScreen.xaml
    /// </summary>
    public partial class WhatWeDo : Screen
    {
        public WhatWeDo(SurfaceWindow1 parentWindow) : base(parentWindow)
        {
            InitializeComponent();

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
    }
}