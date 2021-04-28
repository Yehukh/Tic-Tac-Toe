namespace Tic_Tac_Toe.Engine.Engines
{
    public class AlphaBetaPruningEngine : MiniMaxEngine
    {
        protected override int MiniMax(Board board, bool machineMove, int depth)
        {
            const int alpha = -10_000;
            const int beta = 10_000;
            const int maxScore = alpha;

            
            return this.AlphaBetaPruning(board, machineMove, depth, -beta, -maxScore);
        }
        
        private int AlphaBetaPruning(Board board, bool machineMove, int depth, int alpha, int beta)
        {
            Winner winner = board.CheckWinner();
            if (winner != Winner.None)
                return this.GetScoreForWinner(winner, machineMove, depth);

            if (!board.HasEmptyFields())
                return 0;

            int maxScore = alpha;
            foreach (int index in board.GetEmptyFields())
            {
                Board newBoard = board;     
                newBoard[index] = machineMove ? FieldState.Machine : FieldState.User;
                int score = -this.AlphaBetaPruning(newBoard, !machineMove, depth + 1, -beta, -maxScore);

                if (score > maxScore)
                {
                    maxScore = score;

                    if (maxScore >= beta)
                        break;
                }
            }

            return maxScore;
        }
    }
}
