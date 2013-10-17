using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Team_Roasters
{
    public class Screen : UserControl
    {
        public SurfaceWindow1 parentWindow;

        public SurfaceWindow1 ParentWindow { get { return parentWindow; } }

        protected Screen() { }

        public Screen(SurfaceWindow1 parentWindow)
        {
            this.parentWindow = parentWindow;
        }
    }
}
