
using System.Windows.Input;
using Tic_Tac_Toe.Models;

namespace Tic_Tac_Toe.ViewModels
{
    public class SettingsViewModel
    {
        public static readonly RoutedCommand Command = new RoutedCommand();
        public BoardModel Board { get; set; }

        public ICommand ChangeBoardSize { get; }
        public ICommand ChangeGameMode { get; }
        public ICommand ChangeBotDifficulty { get; }

        public SettingsViewModel(BoardModel board)
        {
            Board = board;

            ChangeBoardSize = new RelayCommand(NotImplementedCommand);
            ChangeGameMode = new RelayCommand(NotImplementedCommand);
            ChangeBotDifficulty = new RelayCommand(NotImplementedCommand);
        }
        private void NotImplementedCommand()
        {

        }
    }
}
