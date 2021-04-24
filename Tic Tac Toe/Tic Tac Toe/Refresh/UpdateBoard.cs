using Tic_Tac_Toe.Boards;
using Tic_Tac_Toe.Views;

namespace Tic_Tac_Toe.Refresheres
{
    internal class UpdateBoard
    {
        internal static void Update()
        {
            foreach (var cell in Board.Cells)
            {
                cell.CanSelect = true;
                cell.Sign = null;
                cell.CanModify = true;
            }
            MainWindow.FirstPlayer = true;
        }

        internal static void MakeUnavailible()
        {
            foreach (var cell in Board.Cells)
            {
                cell.CanSelect = false;
            }
        }
    }
}
