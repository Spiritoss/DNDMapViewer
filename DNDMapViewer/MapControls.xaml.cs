using System;
using System.Collections.Generic;
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
using Microsoft.Win32;

namespace DNDMapViewer
{
    /// <summary>
    /// Interaction logic for MapControls.xaml
    /// </summary>
    public partial class MapControls : UserControl
    {
        Image map = new Image();
        public MapViewer mv;
        public MapControls()
        {
            InitializeComponent();
        }

        

        

        private void btnToggleMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}

