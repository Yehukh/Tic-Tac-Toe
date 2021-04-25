using System.Collections.ObjectModel;
using System.Linq;

namespace Tic_Tac_Toe.Models
{
    public class BoardModel
    {
        private int _rows = 3;
        private int _columns = 3;

        public int Rows
        {
            get => _rows;
            set
            {
                _rows = value;
            }
        }
        public int Columns
        {
            get => _columns;
            set
            {
                _columns = value;
            }
        }

        private ObservableCollection<BoardCellModel> _cells;
        public ObservableCollection<BoardCellModel> Cells
        {
            get
            {
                if (_cells == null || _cells.Count != Rows * Columns)
                {
                    _cells = new ObservableCollection<BoardCellModel>(Enumerable.Range(0, Rows * Columns).Select(i => new BoardCellModel()));
                }
                return _cells;
            }
        }
    }
}