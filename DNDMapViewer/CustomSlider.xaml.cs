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
    /// Interaction logic for CustomSlider.xaml
    /// </summary>
    public partial class CustomSlider : UserControl
    {
        public string textboxHint { get; set; }
        public string textboxTooltip { get; set; }
        public string maxValue { get; set; }
        public string minValue { get; set; }
        public string label { get; set; }

        public string defaultValue { get; set; }


        public CustomSlider()
        {
            
            InitializeComponent();
            this.DataContext = this;

        }

        private void TxBx_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Slider.Value = Convert.ToDouble(TxBx.Text);
            }
            catch { }
        }

        private void TxBx_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TxBx.Text = Slider.Value.ToString("0.");
        }

        public double GetCurrentValue()
        {
            return Slider.Value;
        }

        private void TxBx_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Slider.Value = Convert.ToDouble(TxBx.Text);
            }
            catch { }
        }
    }
}
