using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CheckersProject.src
{

    enum Direction
    {
        Down = 1,
        Up = -1,
        Left = -1,
        Right = 1,
    }

    enum GameState
    {
        unstarted,
        redTurn = -1,
        blackTurn = 1,
        redWin,
        blackWin,
        redForfeit,
        blackForfeit,
    }
    internal class Player
    {
        private Piece[,] board = new Piece[8, 8];
        private GameState state;
        readonly Board B;

        public GameState State { get { return state; } set { state = value; } }

        public Player(Board b)
        {
            B = b;
        }

        public void HighlightValidMoves(Piece p)
        {
            foreach(Pos pos in p.ValidMoves)
            {
                Image i = p.getImageClone();
                i.Opacity = .75;
                ((Button)B.grid.FindName("Button" + pos.Row.ToString() + pos.Column.ToString())).Content = i;
                
            }
        }

        public void ResetHighlights(Piece p)
        {
            foreach(Pos pos in p.ValidMoves)
            {
                ((Button)B.grid.FindName("Button" + pos.Row.ToString() + pos.Column.ToString())).Content = new Image { Source = new BitmapImage(new Uri("/CheckerBlank.png", UriKind.Relative)) };
            }
        }

        public void CheckValidMoves(Piece p) 
        { 
            List<Pos> moves = new List<Pos>();
            p.SetValidMoves(p.CheckValidMoves(board));
        }
        public bool Move(Pos pos, Piece p)
        {
            ResetHighlights(p);
            bool moveFound = false;
            //For now, this is just a really complicated swap afterwards it updates both of the images
            foreach(Pos x in p.ValidMoves)
            {
                if (x.Row == pos.Row && x.Column == pos.Column)
                {
                    moveFound = true;
                    break;
                }
            }
            if (p != null && board[pos.Row, pos.Column] != null && moveFound == true)
            {
                if(Math.Abs(pos.Row - p.Row) > 1 && Math.Abs(pos.Column - p.Column) > 1)
                {
                    if (board[(p.Row + pos.Row) / 2, (p.Column + pos.Column) / 2].ToString() == "CheckersProject.src.BlackPieceDecorator")
                    {
                        B.Player_2_Amount.Text = (Int32.Parse(B.Player_2_Amount.Text) - 1).ToString();
                    }
                    else
                    {
                        B.Player_1_Amount.Text = (Int32.Parse(B.Player_1_Amount.Text) - 1).ToString();
                    }
                    board[(p.Row + pos.Row) / 2, (p.Column + pos.Column) / 2] = new BlankPiece(null, new Pos((p.Row + pos.Row) / 2, (p.Column + pos.Column) / 2));
                    board[(p.Row + pos.Row) / 2, (p.Column + pos.Column) / 2].updateImage(B);

                    Piece temp = board[pos.Row, pos.Column];
                    board[pos.Row, pos.Column] = p;
                    board[p.Row, p.Column] = temp;
                    board[p.Row, p.Column].Row = p.Row;
                    board[p.Row, p.Column].Column = p.Column;
                    temp = board[p.Row, p.Column];
                    p.Row = pos.Row;
                    p.Column = pos.Column;


                    temp.updateImage(B);
                    p.updateImage(B);
                    return true;
                }
                else
                {
                    Piece temp = board[pos.Row, pos.Column];
                    board[pos.Row, pos.Column] = p;
                    board[p.Row, p.Column] = temp;
                    board[p.Row, p.Column].Row = p.Row;
                    board[p.Row, p.Column].Column = p.Column;
                    temp = board[p.Row, p.Column];
                    p.Row = pos.Row;
                    p.Column = pos.Column;

                    temp.updateImage(B);
                    p.updateImage(B);
                    return true;
                }
            }
            return false;

        }

        public void SetPiece(Pos pos, Piece p)
        {
            board[pos.Row, pos.Column] = p;
            p.updateImage(B); 
            /* updateImage just takes the Board xaml, finds the button linked to the piece,
             * and changes the button's content to the correct image*/
        }

        public Piece GetPiece(Pos pos)
        {
            return board[pos.Row, pos.Column];
        }

    }
}
