using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class MainDiagonalPieceBehavior : AbstractPieceBehavior
    {
        /// <summary>
        /// Checks if this piece matches with other pieces in board main diagonal
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override bool CheckPieceMatch(Board board)
        {
            for(int i = 0; i < board.BoardSize; i++)
            {
                if (!Piece.IsIconEqual(board.GetPieceOnRowAndColumn(i, i)))
                    return false;
            }

            return true;
        }
    }
}
