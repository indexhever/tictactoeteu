using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class SecondaryDiagonalPeaceBehavior : AbstractPeaceBehavior
    {
        public override bool CheckPeaceMatch(Board board)
        {
            return false;
        }
    }
}

