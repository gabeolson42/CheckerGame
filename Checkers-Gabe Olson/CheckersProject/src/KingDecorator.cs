using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CheckersProject.src
{
    internal class KingDecorator : ABSPieceDecorator
    {
        string type;
        public KingDecorator(Piece c, Pos pos, string PieceType) : base(c) {
            if(PieceType == "CheckersProject.src.BlackPieceDecorator")
            {
                i.Source = new BitmapImage(new Uri("/BlueKing.png", UriKind.Relative));
            }
            else if(PieceType == "CheckersProject.src.RedPieceDecorator")
            {
                i.Source = new BitmapImage(new Uri("/RedKing.png", UriKind.Relative));
            }

            type = PieceType;
        }
        
        public override void updateImage(Board b)
        {
            Button button = (Button)b.grid.FindName("Button" + Row.ToString() + Column.ToString());
            button.Content = i;

        }

        public override void UpdateComponent()
        {
        }

        public override Piece GetComponent()
        {
            return null;
        }

        public override Image getImage()
        {
            return i;
        }

        public override List<Pos> CheckValidMoves(Piece[,] board)
        {
            List<Pos> moves = new List<Pos>();
            Pos[] positions = new Pos[4];
            positions[0] = CheckValidSpot(board, Row + 1, Column + 1, Direction.Down, Direction.Right);
            positions[1] = CheckValidSpot(board, Row + 1, Column - 1, Direction.Down, Direction.Left);
            positions[2] = CheckValidSpot(board, Row - 1, Column + 1, Direction.Up, Direction.Right);
            positions[3] = CheckValidSpot(board, Row - 1, Column - 1, Direction.Up, Direction.Left);
            foreach (Pos p in positions)
            {
                if (p != null)
                {
                    moves.Add(p);
                }
            }
            return moves;
        }

        public override Pos CheckValidSpot(Piece[,] board, int r, int c, Direction Vertical, Direction Horizontal)
        {
            if (r > 7 || r < 0 || c > 7 || c < 0)
            {
                return null;
            }
            if (board[r, c].ToString() != "CheckersProject.src.BlankPiece" && board[r, c].ToString() != type)
            {
                if (r + ((int)Vertical) > 7 || r + ((int)Vertical) < 0 || c + ((int)Horizontal) > 7 || c + ((int)Horizontal) < 0)
                {
                    return null;
                }

                else if (board[r + ((int)Vertical), c + ((int)Horizontal)].ToString() == "CheckersProject.src.BlankPiece")
                {
                    return new Pos(r + ((int)Vertical), c + ((int)Horizontal));
                }

            }
            else if (board[r, c].ToString() == "CheckersProject.src.BlankPiece")
            {
                return new Pos(r, c);
            }
            return null;
        }


        public override void SetValidMoves(List<Pos> validMoves)
        {
            ValidMoves = validMoves;
        }
        public override Image getImageClone()
        {
            Image image2 = new Image();
            image2.Source = i.Source;
            return image2;
        }

        public override bool CheckPromotion()
        {
            return false;
        }
    }
}
