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
             

    }
}