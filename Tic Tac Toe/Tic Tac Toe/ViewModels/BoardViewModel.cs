using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tic_Tac_Toe.Models;

namespace Tic_Tac_Toe.ViewModels
{
    public class BoardViewModel
    {
        public static readonly RoutedCommand Command = new RoutedCommand();

        public BoardModel Board { get; set; }

        public ICommand Click { get; }

        public BoardViewModel(BoardModel board)
        {
            Board = board;

            Click = new RelayCommand(NotImplementedCommand);
        }
        private void NotImplementedCommand()
        {

        }
    }
}
