using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        private ObservableCollection<BoardCell> _cells;
        public ObservableCollection<BoardCell> Cells
        {
            get
            {
                if (_cells == null)
                    _cells = new ObservableCollection<BoardCell>(Enumerable.Range(0, Rows * Columns).Select(i => new BoardCell()));
                return _cells;
            }
        }
    }
}
