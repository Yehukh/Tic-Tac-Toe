using Tic_Tac_Toe.Engine.Interfaces;

namespace Tic_Tac_Toe.Engine.Engines
{
    public class NextEmptyFieldEngine : IEngine
    {
        public int FindBestMove(Board board)
        {
            foreach (int index in board.GetEmptyFields())
                return index;

            return -1;
        }
    }
}
