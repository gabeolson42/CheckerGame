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
    public partial class Menu : Window
    {
        Factory f = new Factory();
        Button b;

        public Menu()
        {
            //sets the icon image for the menu window
            this.Icon = new BitmapImage(new Uri("..\\..\\CheckerRedTransparent.png", UriKind.Relative));
            b = f.GetSquare(ColorType.Red).changeColor();
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }
        public Menu(Button b)
        {
            this.Icon = new BitmapImage(new Uri("..\\..\\CheckerRedTransparent.png", UriKind.Relative));
            this.b = b;
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void Local_Game_Click(object sender, RoutedEventArgs e)
        {
            Board board = new Board(b);
            this.Close();
            board.Show();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow s = new SettingsWindow();
            s.Show();
            this.Close();
        }
    }
}
