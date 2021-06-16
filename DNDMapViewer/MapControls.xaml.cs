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

namespace DNDMapViewer
{
    /// <summary>
    /// Interaction logic for MapControls.xaml
    /// </summary>
    public partial class MapControls : UserControl
    {
        public MapControls()
        {
            InitializeComponent();
        }

        void SelectMapBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectMapBtn.Background = Brushes.LightBlue;
        }

        void OnClick5(object sender, RoutedEventArgs e)
        {
            btnToggleMenu.Background = Brushes.LightBlue;
        }
    }

}

