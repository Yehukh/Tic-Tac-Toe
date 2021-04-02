using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe.Refresheres;

namespace Tic_Tac_Toe
{
    public static class UserVsBotGameplay
    {
        private static int dice;
        private static string result;

        private static bool _userVsBot;
        public static bool UserVsBot
        {
            get
            {
                return _userVsBot;
            }
            set
            {
                _userVsBot = value;
            }
        }

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
            await SetBotSignAsync(cellBot);
            if (CheckForTheResult.CheckForWin(board, cellBot.Sign, out result) || CheckForTheResult.CheckBoarForTie(board, out result))
            {
                var resetGameWindow = new ResetGameWindow(result);
                UpdateBoard.MakeUnavailible();
                if (resetGameWindow.ShowDialog() == true) UpdateBoard.Update();
            }
        }

        private static async Task SetBotSignAsync(BoardCell cell)
        {
            await Task.Delay(100);
            cell.Sign = "O";
        }
    }
}
