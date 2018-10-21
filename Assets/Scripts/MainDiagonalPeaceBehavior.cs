using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class MainDiagonalPeaceBehavior : PeaceBehavior
    {
        public override bool CheckPeaceMatch(Board board)
        {
            return base.CheckPeaceMatch(board);
        }
    }
}
