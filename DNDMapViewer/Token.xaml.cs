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
        int diameter;
        Brush fill;
        string character;
        bool isDeletable;

        public Token(int diameter, Brush fill, string character, bool isDeletable)
        {
            InitializeComponent();
            this.diameter = diameter;
            this.fill = fill;
            this.character = character;
            this.isDeletable = isDeletable;

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
                dynamic p = this.Parent;
                p.Children.Remove(this);
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
    }
}
