using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class SecondaryDiagonalPeaceBehavior : AbstractPeaceBehavior
    {
        public override bool CheckPeaceMatch(Board board)
        {
            for (int i = 0; i < board.BoardSize; i++)
            {
                if (!Peace.IsIconEqual(board.GetPeace(board.BoardSize-(i+1), i)))
                    return false;
            }

            return true;
        }
    }
}

