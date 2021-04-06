using System;
using System.Windows;
using System.Windows.Controls;
using Tic_Tac_Toe.Boards;
using Tic_Tac_Toe.Checks;
using Tic_Tac_Toe.Gameplay;
using Tic_Tac_Toe.Refresheres;

namespace Tic_Tac_Toe.Pages
{
    /// <summary>
    /// Interaction logic for BoardPage.xaml
    /// </summary>
    public partial class BoardPage : Page
    {
        private string result;

        private delegate void PerformClick(object sender);
        private readonly PerformClick performClick;

        private delegate void BotPerformClick(string[,] boardMat);
        private readonly BotPerformClick botPerformClick;

        public BoardPage()
        {
            InitializeComponent();

            if (UserVsBotGameplay.UserVsBot)
            {
                try
                {
                    switch (UserVsBotGameplay.Difficulty)
                    {
                        case 0:
                            botPerformClick = EasyBotGameplay.MakeMoveBot;
                            break;
                        case 1:
                            
                            break;
                        case 2:
                            botPerformClick = ImpossibleBotGameplay.MakeMoveBot;
                            break;
                        default:
                            throw new Exception("Something went wrong");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

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
                var boardMat = UpdateMatrix.Update();

                if (CheckForTheResult.CheckForWin(boardMat, cell.Sign, out result) || CheckForTheResult.CheckBoarForTie(boardMat, out result))
                {
                    var resetGameWindow = new ResetGameWindow(result);
                    UpdateBoard.MakeUnavailible();
                    if (resetGameWindow.ShowDialog() == true) UpdateBoard.Update();
                }
            }
        }
        private void UserVsBotClick(object sender)
        {
            var cell = (sender as Button).DataContext as BoardCell;
            if (cell.CanModify)
            {
                cell.Sign = MainWindow.FirstPlayer ? "X" : "O";
                cell.CanModify = false;
                MainWindow.FirstPlayer = !MainWindow.FirstPlayer;
                var boardMat = UpdateMatrix.Update();

                if (CheckForTheResult.CheckForWin(boardMat, cell.Sign, out result) || CheckForTheResult.CheckBoarForTie(boardMat, out result))
                {
                    var resetGameWindow = new ResetGameWindow(result);
                    UpdateBoard.MakeUnavailible();
                    if (resetGameWindow.ShowDialog() == true) UpdateBoard.Update();
                    return;
                }
                botPerformClick(boardMat);
            } 
        }
    }
}
