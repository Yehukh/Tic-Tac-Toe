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
        public delegate void PerformClick(object sender);
        public PerformClick performClick;

        public BoardPage()
        {
            InitializeComponent();

            if (UserVsBotGameplay.UserVsBot)
            {
                performClick = UserVsBotClick;
            }
            else
            {
                performClick = UserVsUserClick;
            }
        }
        
        private void CellClick(object sender, RoutedEventArgs e)
        {
            performClick(sender);
        }

        private void UserVsUserClick(object sender)
        {
            var cell = (sender as Button).DataContext as BoardCell;
            if (cell.CanModify)
            {
                cell.Sign = MainWindow.FirstPlayer ? "X" : "O";
                cell.CanModify = false;
                MainWindow.FirstPlayer = !MainWindow.FirstPlayer;
                string[,] boardMat = UpdateMatrix.Update();

                if (CheckForTheResult.CheckForWin(boardMat, cell.Sign, out result) || CheckForTheResult.CheckBoarForTie(boardMat, out result))
                {
                    var resetGameWindow = new ResetGameWindow(result);
                    UpdateBoard.MakeUnavailible();
                    if (resetGameWindow.ShowDialog() == true) UpdateBoard.Update();
                }
            }
        }
        private string[,] boardMat;
        private int dice;
        private async void UserVsBotClick(object sender)
        {
            var cell = (sender as Button).DataContext as BoardCell;
            if (cell.CanModify)
            {
                cell.Sign = "X";
                cell.CanModify = false;
                MainWindow.FirstPlayer = !MainWindow.FirstPlayer;
                boardMat = UpdateMatrix.Update();

                if (CheckForTheResult.CheckForWin(boardMat, cell.Sign, out result) || CheckForTheResult.CheckBoarForTie(boardMat, out result))
                {
                    var resetGameWindow = new ResetGameWindow(result);
                    UpdateBoard.MakeUnavailible();
                    if (resetGameWindow.ShowDialog() == true) UpdateBoard.Update();
                    return;
                }
            }
            //boardMat = BotNextMove(boardMat);
            Random rnd = new Random();
            bool sign = true;
            while (sign)
            {
                dice = rnd.Next(1, boardMat.Length);
                int i = dice / Tic_Tac_Toe.Board.Columns;
                int j = dice % Tic_Tac_Toe.Board.Columns;
                if (boardMat[i, j] == null)
                {
                    boardMat[i, j] = "O";
                    sign = false;
                }
            }
            var cellBot = Tic_Tac_Toe.Board.Cells.ElementAt(dice);
            cellBot.CanModify = false;
            await AsyncSign(cellBot);
            if (CheckForTheResult.CheckForWin(boardMat, cell.Sign, out result) || CheckForTheResult.CheckBoarForTie(boardMat, out result))
            {
                var resetGameWindow = new ResetGameWindow(result);
                UpdateBoard.MakeUnavailible();
                if (resetGameWindow.ShowDialog() == true) UpdateBoard.Update();
            }
        }
        private async Task AsyncSign(BoardCell cell)
        {
            await Task.Delay(100);
            cell.Sign = "O";
        }
    }
}
