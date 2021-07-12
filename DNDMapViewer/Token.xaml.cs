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
    /// Interaction logic for Token.xaml
    /// </summary>
    public partial class Token : UserControl
    {
        public int diameter;
        Brush fill;
        string character;
        bool isDeletable;
        public double zoomValue = 1;
        public int originalDiameter;

        public Token(int diameter, Brush fill, string character, bool isDeletable, int zoomValue, int originalDiameter)
        {
            InitializeComponent();
            this.diameter = diameter;
            this.fill = fill;
            this.character = character;
            this.isDeletable = isDeletable;
            this.zoomValue = zoomValue;
            this.originalDiameter = originalDiameter;

            GenerateToken();
        }
        public Token(Token t)
        {
            InitializeComponent();
            this.diameter = (int)(t.diameter * t.zoomValue);
            this.fill = t.fill;
            this.character = t.character;
            this.isDeletable = true;
            this.zoomValue = t.zoomValue;
            this.originalDiameter = t.originalDiameter;
            GenerateToken();
        }

        void GenerateToken()
        {
            elps.Fill = fill;
            objectLabel.Text = character;
            this.Width = diameter;
            this.Height = diameter;
        }

        private void elps_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isDeletable)
            {
                try
                {
                    dynamic p = this.Parent;
                    p.Children.Remove(this);
                }
                catch { }
                
            }
        }

        public void SetDiameter(int diameter)
        {
            this.diameter = diameter;
            GenerateToken();
        }

        public void SetFill(Brush fill)
        {
            this.fill = fill;
            GenerateToken();
        }
        

        public void SetCharacter(string character)
        {
            this.character = character;
            GenerateToken();
        }

        public void SetDeletable(bool isDeletable)
        {
            this.isDeletable = isDeletable;
        }

        public void ZoomSize(double zoomLevel)
        {
            zoomValue = zoomLevel;
            diameter = (int)(originalDiameter * zoomLevel); 
            if (diameter < 0)
            {
                // do nothing
            } else
            {
                GenerateToken();
            }
        }
    }
}
