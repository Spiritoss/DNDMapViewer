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
    /// Interaction logic for TokenControl.xaml
    /// </summary>
    public partial class TokenControl : UserControl
    {
        Token preview;
        int diameter;
        //Brush fill;
        string character;
        //bool isDeletable;

        public TokenControl()
        {
            InitializeComponent();
            preview = new Token(100, Brushes.Red, "A", false);
            Grid.SetColumn(preview, 0);
            Grid.SetRow(preview, 0);
            preview.MouseLeftButtonDown += new MouseButtonEventHandler(AddToken);
            container.Children.Add(preview);
        }

        private void cmbSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value = cmbSize.SelectedValue.ToString();

            switch (value)
            {
                case "Tiny":
                    preview.SetDiameter(30);
                    break;
                case "Small":
                    preview.SetDiameter(40);
                    break;
                case "Medium":
                    preview.SetDiameter(40);
                    break;
                case "Large":
                    preview.SetDiameter(80);
                    break;
                case "Huge":
                    preview.SetDiameter(120);
                    break;
                case "Gargantuan":
                    preview.SetDiameter(160);
                    break;
                default:
                    MessageBox.Show("Please select a token size");
                    break;
            }
        }

        private void cprColour_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            MessageBox.Show("change");
            Brush fill = new SolidColorBrush(cprColour.Color); 
            preview.SetFill(fill);
            Ellipse test = new Ellipse();
            test.Stroke = Brushes.Black;
            test.Width = 50;
            test.Height = 50;
            test.Fill = fill;
            test.HorizontalAlignment = HorizontalAlignment.Left;
            test.VerticalAlignment = VerticalAlignment.Center;
            container.Children.Add(test);
        }

        private void txtChar_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txtChar.Text != null)
            {
                character = txtChar.Text;
                preview.SetCharacter(character);
            }
        }

        private void AddToken(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click");
        }
    }
}
