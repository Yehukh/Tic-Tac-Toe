using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.Boards
{
    public static class Board
    {
        private static int _rows = 3;
        private static int _columns = 3;
        public static int Rows
        {
            get => _rows;
            set
            {
                _rows = value;
            }
        }
        public static int Columns
        {
            get => _columns;
            set
            {
                _columns = value;
            }
        }

        private static ObservableCollection<BoardCell> _cells;
        public static ObservableCollection<BoardCell> Cells
        {
            get
            {
                if (_cells == null || _cells.Count != Rows*Columns)
                {
                    _cells = new ObservableCollection<BoardCell>(Enumerable.Range(0, Rows * Columns).Select(i => new BoardCell()));
                }
                return _cells;
            }
        }
    }
}
