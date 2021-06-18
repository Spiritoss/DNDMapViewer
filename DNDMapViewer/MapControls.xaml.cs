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
        public MapControls()
        {
            InitializeComponent();
        }

        void SelectMapBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (open.ShowDialog() == true)
            {
                string uri = open.FileName;
                /*
                MessageBox.Show(imageName);
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imageName, UriKind.RelativeOrAbsolute);
                bitmap.EndInit();

                ImageBrush ib = new ImageBrush();
                ib.ImageSource = bitmap;
                */
                MapViewer mv = new MapViewer();
                mv.GetMap(uri);

            }
        }
        

        void OnClick5(object sender, RoutedEventArgs e)
        {
            btnToggleMenu.Background = Brushes.LightBlue;
        }
    }

}

