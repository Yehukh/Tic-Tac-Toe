using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe;

namespace Tic_Tac_Toe
{
    public class CheckWinner
    {
		private static int block;
        public static bool CheckForResult(string[,] matrix)
        {

            switch (Board.Columns)
            {
				case 3:
					block = 3;
					break;
				case 4:
					block = 4;
					break;
				case 5:
					block = 4;
					break;
				case 6:
					block = 4;
					break;
				default:
					block = 5;
					break;
			}
			for (int col = 0; col < Board.Columns - block + 1; col++)
			{
				for (int row = 0; row < Board.Columns - block + 1; row++)
				{
					if (CheckDiagonals(matrix, col, row) || CheckLanes(matrix, col, row)) 
					{
						return true;
					}
					
				}
			}
			return false;
		}
		private static bool CheckDiagonals(string[,] matrix, int offsetX, int offsetY)
        {
			bool toright, toleft;
			toright = true;
			toleft = true;
			for (int i = 0; i < block; i++)
			{
				toright &= (matrix[i + offsetX, i + offsetY] == "X");
				toleft &= (matrix[block - i - 1 + offsetX, i + offsetY] == "X");
			}

			return (toright || toleft);
		}
		private static bool CheckLanes(string[,] matrix, int offsetX, int offsetY)
		{
			bool cols, rows;
			for (int col = offsetX; col < block + offsetX; col++)
			{
				cols = true;
				rows = true;
				for (int row = offsetY; row < block + offsetY; row++)
				{
					cols &= (matrix[col, row] == "X");
					rows &= (matrix[row, col] == "X");
				}

				
				if (cols || rows) return true;
			}

			return false;
		}
	}
}
