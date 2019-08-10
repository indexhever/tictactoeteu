using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public abstract class AbstractPieceBehavior
    {
        private Piece piece;
        public Piece Piece
        {
            get
            {
                return piece;
            }
            set
            {
                piece = value;
            }
        }
        
        public abstract bool CheckPieceMatch(Board board);
    }
}

