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

        private static int _difficulty;
        public static int Difficulty
        {
            get
            {
                return _difficulty;
            }
            set
            {
                _difficulty = value;
            }
        }


        public static async Task SetBotSignAsync(BoardCell cell)
        {
            await Task.Delay(100);
            cell.Sign = "O";
        }
    }
}
