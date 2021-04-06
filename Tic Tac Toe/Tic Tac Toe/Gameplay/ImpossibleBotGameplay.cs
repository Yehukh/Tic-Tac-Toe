using System;
using System.Collections.Generic;
using Tic_Tac_Toe.Boards;

namespace Tic_Tac_Toe.Gameplay
{
    public static class ImpossibleBotGameplay
    {

        public static void MakeMoveBot(string[,] board)
        {
            var emptyFields = GetEmptyFields(board);
            
        }

        private static List<int> GetEmptyFields(string[,] boardMat)
        {
            List<int> emptyList = new List<int>();
            int col = Board.Columns;
            for (int i = 0; i<col;i++)
            {
                for(int j = 0;j< col; j++)
                {
                    if (boardMat[i, j] == null)
                    {
                        emptyList.Add(i*col + j);
                    }
                }
            }

            return emptyList;
        }
    }
}
