namespace Tic_Tac_Toe.Engine.Interfaces
{
    public interface IGame
    {
        Winner Winner { get; }

        MoveResult MakeMachineMove();
        MoveResult MakeMove(int fieldIdx);
    }
}
