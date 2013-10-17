namespace Team_Roasters.Screens
{
    /// <summary>
    /// Interaction logic for FamilySupportScreen.xaml
    /// </summary>
    public partial class Volunteer : Screen
    {
        public Volunteer(SurfaceWindow1 parentWindow) : base(parentWindow)
        {
            InitializeComponent();           
        }

        private void SurfaceButton_Back(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
        }

        private void SurfaceButton_WhatIsVolunteering(object sender, System.Windows.RoutedEventArgs e)
        {
            WhatIsVolunteering.Visibility = System.Windows.Visibility.Visible;
            WhoCanVolunteer.Visibility = System.Windows.Visibility.Collapsed;
            WhatWouldIDo.Visibility = System.Windows.Visibility.Collapsed;
            Volunteering.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void SurfaceButton_WhoCanVolunteer(object sender, System.Windows.RoutedEventArgs e)
        {
            WhatIsVolunteering.Visibility = System.Windows.Visibility.Collapsed;
            WhoCanVolunteer.Visibility = System.Windows.Visibility.Visible;
            WhatWouldIDo.Visibility = System.Windows.Visibility.Collapsed;
            Volunteering.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void SurfaceButton_WhatWouldIDo(object sender, System.Windows.RoutedEventArgs e)
        {
            WhatIsVolunteering.Visibility = System.Windows.Visibility.Collapsed;
            WhoCanVolunteer.Visibility = System.Windows.Visibility.Collapsed;
            WhatWouldIDo.Visibility = System.Windows.Visibility.Visible;
            Volunteering.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void SurfaceButton_Volunteering(object sender, System.Windows.RoutedEventArgs e)
        {
            WhatIsVolunteering.Visibility = System.Windows.Visibility.Collapsed;
            WhoCanVolunteer.Visibility = System.Windows.Visibility.Collapsed;
            WhatWouldIDo.Visibility = System.Windows.Visibility.Collapsed;
            Volunteering.Visibility = System.Windows.Visibility.Visible;
        }
    }
}