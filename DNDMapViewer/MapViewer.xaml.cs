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
    /// Interaction logic for MapViewer.xaml
    /// </summary>
    public partial class MapViewer : UserControl
    {
        public TokenControl tc;
        private bool isMouseDown;
        Token selected;
        public MapViewer()
        {
            InitializeComponent();
        }

        public void AddNewToken(Token t, double x, double y)
        {
            Token tk = new Token(t);
            tk.MouseLeftButtonDown += new MouseButtonEventHandler(MouseDown);
            tk.MouseLeftButtonUp += new MouseButtonEventHandler(MouseUp);
            tk.MouseMove += new MouseEventHandler(MoveSelected);
            Canvas.SetTop(tk, y);
            Canvas.SetLeft(tk, x);
            mapCanvas.Children.Add(tk);

        }

        public void GetMap(string uri)
        {
            //MessageBox.Show(uri);
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(uri, UriKind.RelativeOrAbsolute));
            mapCanvas.MinWidth = ib.ImageSource.Width;
            mapCanvas.MinHeight = ib.ImageSource.Height;
            mapCanvas.MaxWidth = ib.ImageSource.Width;
            mapCanvas.MaxHeight = ib.ImageSource.Height;
            mapCanvas.Background = ib;
        }

        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = true;
            selected = (Token)sender;
        }

        private void MouseUp(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = false;
            selected = null;
        }

        private void MoveSelected(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point P = Mouse.GetPosition(mapCanvas);
                Canvas.SetTop((Token)selected, P.Y - ((Token)selected).Width / 2);
                Canvas.SetLeft((Token)selected, P.X - ((Token)selected).Height / 2);
            }
            
        }
    }
}
