using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Threading;

namespace DNDMapViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            mapControls.tokenControls.mv = mapViewer;
            mapControls.mv = mapViewer;
            mapViewer.mw = this;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (((MenuItem)sender).Header.Equals("hide"))
            {
                mapControls.Width = 320;
                Task.Run(() => HideMenuControls());
                
            } else
            {
                mapControls.Width = 0;
                Task.Run(() => ShowMenuControls());
                
                
            }
        }
        private void HideMenuControls()
        {
            
            for (int i = 0; i < 32; i++)
            {
                this.Dispatcher.Invoke(() =>
                {
                    mapControls.Width -= 10;
                });
                
                Thread.Sleep(1);
            }
        }
        private void ShowMenuControls()
        {
            
            for (int i = 0; i < 32; i++)
            {
                this.Dispatcher.Invoke(() =>
                {
                    mapControls.Width += 10;
                });

                Thread.Sleep(1);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
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

                mapViewer.GetMap(uri);

            }
        }
    }
}
