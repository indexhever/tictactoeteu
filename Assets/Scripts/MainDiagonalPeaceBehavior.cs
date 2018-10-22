using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class MainDiagonalPeaceBehavior : AbstractPeaceBehavior
    {
        /// <summary>
        /// Checks if this peace matches with other peaces in board main diagonal
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override bool CheckPeaceMatch(Board board)
        {
            for(int i = 0; i < board.BoardSize; i++)
            {
                if (!Peace.IsIconEqual(board.GetPeace(i, i)))
                    return false;
            }

            return true;
        }
    }
}
