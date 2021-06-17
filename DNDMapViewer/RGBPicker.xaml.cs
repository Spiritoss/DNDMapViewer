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
    /// Interaction logic for RGBPicker.xaml
    /// </summary>
    public partial class RGBPicker : UserControl
    {
        Brush selectedColor { get; set; }
        public TokenControl tc;
        public RGBPicker()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }

        private void setButton_Click(object sender, RoutedEventArgs e)
        {
            var brush = new SolidColorBrush(Color.FromArgb(255, (byte)R.GetCurrentValue(), (byte)G.GetCurrentValue(), (byte)B.GetCurrentValue()));
            selectedColor = brush;
            tc.SetPreviewColor(brush);
        }

        public Brush GetSelectedColor()
        {
            return selectedColor;
        }
    }
}
