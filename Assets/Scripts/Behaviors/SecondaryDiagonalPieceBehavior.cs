using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class SecondaryDiagonalPieceBehavior : AbstractPieceBehavior
    {
        public override bool CheckPieceMatch(Board board)
        {
            for (int i = 0; i < board.BoardSize; i++)
            {
                if (!Piece.IsIconEqual(board.GetPieceOnRowAndColumn(board.BoardSize-(i+1), i)))
                    return false;
            }

            return true;
        }
    }
}

