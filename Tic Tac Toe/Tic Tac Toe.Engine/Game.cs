using System;
using Tic_Tac_Toe.Engine.Engines;
using Tic_Tac_Toe.Engine.Interfaces;

namespace Tic_Tac_Toe.Engine
{
	public class Game : IGame
	{
		private Board _board = new Board();
		private readonly IEngine _engine;
		
		public Game() : this(new CachingEngine(new AlphaBetaPruningEngine())) { }
		public Game(IEngine engine) => _engine = engine ?? throw new ArgumentNullException(nameof(engine));
		
		public ref Board Board => ref _board;
		public Winner Winner { get; internal set; } = Winner.None;
		
		public MoveResult MakeMove(int fieldIdx)
		{
			if (!_board.IsMoveLegal(fieldIdx)) return MoveResult.IllegalMove;

			return PerformMove(fieldIdx, FieldState.User);
		}
		
		public MoveResult MakeMachineMove()
		{
			int bestMove = _engine.FindBestMove(_board);

			if (bestMove > -1)
				return PerformMove(bestMove, FieldState.Machine);
			else
				return new MoveResult(false, true);
		}
		
		private MoveResult PerformMove(int fieldIdx, FieldState fieldState)
		{
			_board[fieldIdx] = fieldState;
			CheckWinner();

			return new MoveResult(true, IsFinal());
		}
		
		internal void CheckWinner() => Winner = _board.CheckWinner();
		
		internal bool IsFinal()
		{
			if (Winner == Winner.None)
			{
				if (_board.HasEmptyFields())
					return false;

				Winner = Winner.Draw;
			}

			return true;
		}
	}
}
