
using Tic_Tac_Toe.Models;

namespace Tic_Tac_Toe.ViewModels
{
    public class MainViewModel
    {
        private readonly BoardModel _board;

        public BoardViewModel Board { get; set; }
        public SettingsViewModel Settings { get; set; }

        public MainViewModel()
        {
            _board = new BoardModel();

            Board = new BoardViewModel(_board);
            Settings = new SettingsViewModel(_board);
        }
    }
}
