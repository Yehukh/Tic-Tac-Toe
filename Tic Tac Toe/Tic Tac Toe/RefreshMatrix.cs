using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public static class RefreshMatrix
    {
        public static string[,] UpdateMat()
        {
            int n = Board.Rows;
            string[,] cells = new string[n, n];
            string[] cmat = Board.Cells.Select(c => c.Sign).ToArray();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cells[i, j] = cmat[i * n + j];
                }
            }
            return cells;
        }
    }
}
