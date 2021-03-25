using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tic_Tac_Toe.Refresheres;

namespace Tic_Tac_Toe.Pages
{
    /// <summary>
    /// Interaction logic for BoardPage.xaml
    /// </summary>
    public partial class BoardPage : Page
    {
       
        public BoardPage()
        {
            InitializeComponent();
        }

        private bool _firstPlayer = true;
        private void CellClick(object sender, RoutedEventArgs e)
        {

            var cell = (sender as Button).DataContext as BoardCell;
            cell.Sign = _firstPlayer ? "X" : "O";
            _firstPlayer = !_firstPlayer;

            string[,] boardMat = RefreshMatrix.Update();

            if (CheckWinner.CheckForResult(boardMat, cell.Sign))
            {
                var resetGameWindow = new ResetGameWindow($"{cell.Sign} won!!");
                UpdateBoard.MakeUnavailible();
                if (resetGameWindow.ShowDialog() == true) UpdateBoard.Update();
            }
            else
            {
                if (CheckForTie.CheckBoarForTie(boardMat))
                {
                    var resetGameWindow = new ResetGameWindow("Tie");
                    UpdateBoard.MakeUnavailible();
                    if (resetGameWindow.ShowDialog() == true) UpdateBoard.Update();
                }
            }
        }
    }
}
