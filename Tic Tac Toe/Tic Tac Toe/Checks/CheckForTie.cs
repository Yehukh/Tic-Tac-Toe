using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public static class CheckForTie
    {
        public static bool CheckBoarForTie(string[,] matrix)
        {
            for(int i = 0; i < Board.Columns; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (matrix[i, j] == null) return false;
                }
            }
            return true;
        }
    }
}
