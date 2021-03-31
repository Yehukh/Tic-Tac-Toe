using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
