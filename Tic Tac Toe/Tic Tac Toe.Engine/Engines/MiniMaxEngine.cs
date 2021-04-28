using Tic_Tac_Toe.Engine.Interfaces;

namespace Tic_Tac_Toe.Engine.Engines
{
    public class MiniMaxEngine : IEngine
    {
        public int FindBestMove(Board board)
        {

            int bestMove = -1;
            int bestScore = int.MinValue;

            foreach (int index in board.GetEmptyFields())
            {
                Board newBoard = board;     
                newBoard[index] = FieldState.Machine;
                int score = -this.MiniMax(newBoard, machineMove: false, depth: 0);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = index;
                }
            }

            return bestMove;
        }
        
        protected virtual int MiniMax(Board board, bool machineMove, int depth)
        {
            Winner winner = board.CheckWinner();
            if (winner != Winner.None)
                return this.GetScoreForWinner(winner, machineMove, depth);

            if (!board.HasEmptyFields())
                return 0;

            int maxScore = int.MinValue;
            foreach (int index in board.GetEmptyFields())
            {
                Board newBoard = board;   
                newBoard[index] = machineMove ? FieldState.Machine : FieldState.User;
                int score = -this.MiniMax(newBoard, !machineMove, depth + 1);

                if (score > maxScore)
                    maxScore = score;
            }

            return maxScore;
        }
        
        
        internal int GetScoreForWinner(Winner winner, bool machineMove, int depth)
        {
            Winner me = machineMove
                ? Winner.Machine
                : Winner.User;

            return winner == me
                ? 10 - depth
                : -10 + depth;
        }
    }
}
