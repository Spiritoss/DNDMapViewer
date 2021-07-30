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
        public double zoomDelta = 1;
        double zoomAmount = 0.1;
        double imageHeight;
        double imageWidth;
        public MainWindow mw;
        public MapViewer()
        {
            InitializeComponent();
        }

        public void AddNewToken(Token t, double x, double y)
        {
            
            t.zoomValue = zoomDelta;
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
            imageHeight = ib.ImageSource.Height;
            imageWidth = ib.ImageSource.Width;
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
                ((Token)selected).percentageX = VisualTreeHelper.GetOffset((Token)selected).X / (imageWidth * zoomDelta);
                ((Token)selected).percentageY = VisualTreeHelper.GetOffset((Token)selected).Y / (imageHeight * zoomDelta);
            }
            
        }

        private void mapCanvas_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            int sign = 1;
            if (e.Delta > 0)
            {
                zoomDelta += zoomAmount;
                sign = 1;

            } else
            {
                zoomDelta -= (zoomDelta > 0.2? zoomAmount : 0);
                sign = -1;
            }
            
            //zoomDelta += sign * zoomAmount;
            foreach (Token t in mapCanvas.Children)
            {
                

                t.ZoomSize(zoomDelta);

                

                Canvas.SetTop(t, (t.percentageY * (imageHeight * zoomDelta)));
                Canvas.SetLeft(t, (t.percentageX * (imageWidth * zoomDelta)));
                


                

            }

            mapCanvas.MaxHeight = imageHeight * zoomDelta;
            mapCanvas.MaxWidth = imageWidth * zoomDelta;

            mapCanvas.MinHeight = imageHeight * zoomDelta;
            mapCanvas.MinWidth = imageWidth * zoomDelta;
            mw.ZoomDisplay.Content = zoomDelta.ToString(".00") + "x";
            e.Handled = true;

            
        }

        public void zoomMap(double zoomDelta)
        {
            this.zoomDelta = zoomDelta;

            foreach (Token t in mapCanvas.Children)
            {


                t.ZoomSize(zoomDelta);



                Canvas.SetTop(t, (t.percentageY * (imageHeight * zoomDelta)));
                Canvas.SetLeft(t, (t.percentageX * (imageWidth * zoomDelta)));





            }

            mapCanvas.MaxHeight = imageHeight * zoomDelta;
            mapCanvas.MaxWidth = imageWidth * zoomDelta;

            mapCanvas.MinHeight = imageHeight * zoomDelta;
            mapCanvas.MinWidth = imageWidth * zoomDelta;
            mw.ZoomDisplay.Content = zoomDelta.ToString(".00") + "x";
        }

        private void ScrollViewer_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            
        }
    }
}
