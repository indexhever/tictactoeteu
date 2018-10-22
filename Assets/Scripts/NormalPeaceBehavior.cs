using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class NormalPeaceBehavior : AbstractPeaceBehavior
    {
        /// <summary>
        /// Checks if this peace matches with other peaces in peace's same horizontal or vertical
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override bool CheckPeaceMatch(Board board)
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
            return Peace.IsIconEqual(board.GetPeace(Peace.Row, i));
        }

        private bool HasVerticalMatch(Board board, int i)
        {
            return Peace.IsIconEqual(board.GetPeace(i, Peace.Column));
        }
    }
}

