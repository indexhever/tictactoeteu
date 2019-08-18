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
            private set
            {
                piece = value;
            }
        }

        public virtual void Initialize(Piece piece)
        {
            Piece = piece;
        }
        
        public abstract bool CheckPieceMatch(Board board);
    }
}

