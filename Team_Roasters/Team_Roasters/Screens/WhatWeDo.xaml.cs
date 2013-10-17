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
            
        }

        private void SurfaceButton_OurPeople(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void SurfaceButton_OurHistory(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void SurfaceButton_HowWeHelp(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}