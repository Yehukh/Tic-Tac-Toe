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
        public string result;

        public BoardPage()
        {
            InitializeComponent();
        }
        
        private void CellClick(object sender, RoutedEventArgs e)
        {
            var cell = (sender as Button).DataContext as BoardCell;
            cell.Sign = MainWindow.FirstPlayer ? "X" : "O";
            MainWindow.FirstPlayer = !MainWindow.FirstPlayer;

            string[,] boardMat = RefreshMatrix.Update();

            if (CheckForTheResult.CheckForWin(boardMat, cell.Sign, out result)||CheckForTheResult.CheckBoarForTie(boardMat, out result))
            {
                var resetGameWindow = new ResetGameWindow(result);
                UpdateBoard.MakeUnavailible();
                if (resetGameWindow.ShowDialog() == true) UpdateBoard.Update();
            }
        }
    }
}
