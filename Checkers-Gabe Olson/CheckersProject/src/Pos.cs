using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersProject.src
{
    internal class Pos
    {
        private int row, column;

        public Pos(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
        public int Row
        {
            get { return row; }
            set { row = value;}
        }

        public int Column
        {
            get { return column; }
            set { column = value; }
        }
    }
}
