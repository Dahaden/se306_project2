namespace Team_Roasters.Screens
{
    /// <summary>
    /// Interaction logic for FamilySupportScreen.xaml
    /// </summary>
    public partial class FamilySupportScreen : Screen
    {
        public FamilySupportScreen(SurfaceWindow1 parentWindow) : base(parentWindow)
        {
            InitializeComponent();

        }

        private void SurfaceButton_ParentResources(object sender, System.Windows.RoutedEventArgs e)
        {
            Parent_Resources.Visibility = System.Windows.Visibility.Visible;

            Holiday_Homes.Visibility = System.Windows.Visibility.Collapsed;
            Support_Services.Visibility = System.Windows.Visibility.Collapsed;
            Scholarships.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void SurfaceButton_Back(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
        }

        private void SurfaceButton_HolidayHomes(object sender, System.Windows.RoutedEventArgs e)
        {
            Holiday_Homes.Visibility = System.Windows.Visibility.Visible;

            Parent_Resources.Visibility = System.Windows.Visibility.Collapsed;
            Support_Services.Visibility = System.Windows.Visibility.Collapsed;
            Scholarships.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void SurfaceButton_SupportServices(object sender, System.Windows.RoutedEventArgs e)
        {
            Support_Services.Visibility = System.Windows.Visibility.Visible;

            Holiday_Homes.Visibility = System.Windows.Visibility.Collapsed;
            Parent_Resources.Visibility = System.Windows.Visibility.Collapsed;
            Scholarships.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void SurfaceButton_Scholarships(object sender, System.Windows.RoutedEventArgs e)
        {
            Scholarships.Visibility = System.Windows.Visibility.Visible;

            Holiday_Homes.Visibility = System.Windows.Visibility.Collapsed;
            Support_Services.Visibility = System.Windows.Visibility.Collapsed;
            Parent_Resources.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}