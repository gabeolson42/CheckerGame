using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CheckersProject.src
{
    public interface ISquare
    {
        Button changeColor();
    }

    public interface SquareFactory
    {
        ISquare GetSquare(ColorType color);
    }

    public enum ColorType
    {
        Blue,
        Red,
        Purple,
        Magenta,
        White,
        Indigo,
    }

    public class Factory : SquareFactory
    {
        public ISquare GetSquare(ColorType color)
        {
            //This switch statement calls a class to generate a colored button depending
            //on what the user has requested. 
            switch (color)
            {
                case ColorType.Blue:
                    return new Blue();
                case ColorType.Red:
                    return new Red();
                case ColorType.Purple:
                    return new Purple();
                case ColorType.Magenta:
                    return new Magenta();
                case ColorType.White:
                    return new White();
                case ColorType.Indigo:
                    return new Indigo();
                default:
                    return null;
            }

        }
    }

    public class Blue : ISquare
    {
        public Button changeColor()
        {
            Button b = new Button { Background = new SolidColorBrush(Colors.Blue) };  
            return b;
        }
    }
    public class Red : ISquare
    {
        public Button changeColor()
        {
            Button b = new Button { Background = new SolidColorBrush(Colors.Red) };
            return b;
        }
    }

    public class Purple : ISquare
    {
        public Button changeColor()
        {
            Button b = new Button { Background = new SolidColorBrush(Colors.Purple) };
            return b;
        }
    }

    public class Magenta : ISquare
    {
        public Button changeColor()
        {
            Button b = new Button { Background = new SolidColorBrush(Colors.Magenta) };
            return b;
        }
    }
    public class White : ISquare
    {
        public Button changeColor()
        {
            Button b = new Button { Background = new SolidColorBrush(Colors.Azure) };
            return b;
        }
    }
    public class Indigo : ISquare
    {
        public Button changeColor()
        {
            Button b = new Button { Background = new SolidColorBrush(Colors.Indigo) };
            return b;
        }
    }
}
