using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe;

namespace Tic_Tac_Toe
{
    public class CheckForTheResult
    {
		private static int block;
        public static bool CheckForWin(string[,] matrix, string symbol, out string result)
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
					if (CheckDiagonals(matrix, col, row, symbol) || CheckLanes(matrix, col, row, symbol)) 
					{
						result = $"{symbol} won!";
						return true;
					}
					
				}
			}
			result = "";
			return false;
		}
		private static bool CheckDiagonals(string[,] matrix, int offsetX, int offsetY, string symbol)
        {
			bool toright, toleft;
			toright = true;
			toleft = true;
			for (int i = 0; i < block; i++)
			{
				toright &= (matrix[i + offsetX, i + offsetY] == symbol);
				toleft &= (matrix[block - i - 1 + offsetX, i + offsetY] == symbol);
			}

			return (toright || toleft);
		}
		private static bool CheckLanes(string[,] matrix, int offsetX, int offsetY, string symbol)
		{
			bool cols, rows;
			for (int col = offsetX; col < block + offsetX; col++)
			{
				cols = true;
				rows = true;
				for (int row = offsetY; row < block + offsetY; row++)
				{
					cols &= (matrix[col, row] == symbol);
					rows &= (matrix[row, col] == symbol);
				}

				
				if (cols || rows) return true;
			}

			return false;
		}
		public static bool CheckBoarForTie(string[,] matrix, out string result)
		{
			
			for (int i = 0; i < Board.Columns; i++)
			{
				for (int j = 0; j < Board.Columns; j++)
				{
					if (matrix[i, j] == null)
                    {
						result = "";
						return false;
					}
				}
			}
			result = "Tie!";
			return true;
		}
	}
}
