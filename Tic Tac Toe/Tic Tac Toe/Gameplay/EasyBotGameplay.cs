using System;
using System.Linq;
using Tic_Tac_Toe.Boards;
using Tic_Tac_Toe.Checks;
using Tic_Tac_Toe.Refresheres;
using Tic_Tac_Toe.Views;

namespace Tic_Tac_Toe
{
    public static class EasyBotGameplay
    {
        private static int dice;
        private static string result;

        public static async void MakeMoveBot(string[,] board)
        {
            Random rnd = new Random();
            bool notFounded = true;
            while (notFounded)
            {
                dice = rnd.Next(1, board.Length);
                int i = dice / Board.Columns;
                int j = dice % Board.Columns;
                if (board[i, j] == null)
                {
                    board[i, j] = MainWindow.FirstPlayer ? "X" : "O";
                    MainWindow.FirstPlayer = !MainWindow.FirstPlayer;

                    notFounded = false;
                }
            }
            var cellBot = Board.Cells.ElementAt(dice);
            cellBot.CanModify = false;
            await UserVsBotGameplay.SetBotSignAsync(cellBot);
            if (CheckForTheResult.CheckForWin(board, cellBot.Sign, out result) || CheckForTheResult.CheckBoarForTie(board, out result))
            {
                var resetGameWindow = new ResetGameWindow(result);
                UpdateBoard.MakeUnavailible();
                if (resetGameWindow.ShowDialog() == true) UpdateBoard.Update();
            }
        }
    }
}
