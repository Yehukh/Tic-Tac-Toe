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

            string[,] boardMat = RefreshMatrix.UpdateMat();

            if (CheckWinner.CheckForResult(boardMat, cell.Sign))
            {
                var resetGameWindow = new ResetGameWindow($"{cell.Sign} won!!");
                if (resetGameWindow.ShowDialog() == true)
                {
                    
                }
            }
            else
            {
                if (CheckForTie.CheckBoarForTie(boardMat))
                {
                    var resetGameWindow = new ResetGameWindow("Tie");
                    if (resetGameWindow.ShowDialog() == true)
                    {

                    }
                }
            }
        }
    }
}
