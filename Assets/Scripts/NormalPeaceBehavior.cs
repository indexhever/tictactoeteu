using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class NormalPieceBehavior : AbstractPieceBehavior
    {
        /// <summary>
        /// Checks if this peace matches with other peaces in peace's same horizontal or vertical
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
            return Piece.IsIconEqual(board.GetPiece(Piece.Row, i));
        }

        private bool HasVerticalMatch(Board board, int i)
        {
            return Piece.IsIconEqual(board.GetPiece(i, Piece.Column));
        }
    }
}

