using CheckersProject.src;
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
using System.Windows.Shapes;

namespace CheckersProject
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        Factory f = new Factory();

        public SettingsWindow()
        {
            //This sets the icon image for the window.
            this.Icon = new BitmapImage(new Uri("..\\..\\CheckerRedTransparent.png", UriKind.Relative));
            InitializeComponent();
        }

        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetSquare(ColorType.Red).changeColor();
            Menu m = new Menu(b);
            this.Close();
            m.Show();
            
        }

        private void BlueButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetSquare(ColorType.Blue).changeColor();
            Menu m = new Menu(b);
            this.Close();
            m.Show();
        }

        private void PurpleButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetSquare(ColorType.Purple).changeColor();
            Menu m = new Menu(b);
            this.Close();
            m.Show();

        }

        private void MagentaButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetSquare(ColorType.Magenta).changeColor();
            Menu m = new Menu(b);
            this.Close();
            m.Show();

        }

        private void WhiteButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetSquare(ColorType.White).changeColor();
            Menu m = new Menu(b);
            this.Close();
            m.Show();

        }

        private void IndigoButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetSquare(ColorType.Indigo).changeColor();
            Menu m = new Menu(b);
            this.Close();
            m.Show();

        }
    }
}
