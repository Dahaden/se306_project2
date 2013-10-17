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

        }

        private void SurfaceButton_Back(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.popScreen();
        }

        private void SurfaceButton_HolidayHomes(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void SurfaceButton_SupportServices(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void SurfaceButton_Scholarships(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}