using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class NormalPieceBehavior : AbstractPieceBehavior
    {
        /// <summary>
        /// Checks if this piece matches with other pieces in piece's same horizontal or vertical
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override bool CheckPieceMatch(Board board)
        {
            bool hasHorizontalMatch = true;
            bool hasVerticalMatch = true;

            for (int i = 0; i < board.BoardSize; i++)
            {
                if (!HasHorizontalMatch(board, i))
                    hasHorizontalMatch = false;

                if (!HasVerticalMatch(board, i))
                    hasVerticalMatch = false;
            }

            return hasHorizontalMatch || hasVerticalMatch;
        }

        private bool HasHorizontalMatch(Board board, int i)
        {
            return Piece.IsIconEqual(board.GetPieceOnRowAndColumn(Piece.Row, i));
        }

        private bool HasVerticalMatch(Board board, int i)
        {
            return Piece.IsIconEqual(board.GetPieceOnRowAndColumn(i, Piece.Column));
        }
    }
}

