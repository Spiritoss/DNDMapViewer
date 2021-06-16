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
    /// Interaction logic for PaintControl.xaml
    /// </summary>
    public partial class PaintControl : UserControl
    {
        public PaintControl()
        {
            InitializeComponent();           
        }

        private void cmbBrushSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cprPaint_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            
        }
    }
}
