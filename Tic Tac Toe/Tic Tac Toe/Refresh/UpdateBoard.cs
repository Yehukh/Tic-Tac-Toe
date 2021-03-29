using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
