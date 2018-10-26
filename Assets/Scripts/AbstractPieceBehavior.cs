using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public abstract class AbstractPieceBehavior
    {
        private Piece peace;
        public Piece Piece
        {
            get
            {
                return peace;
            }
            set
            {
                peace = value;
            }
        }
        
        public abstract bool CheckPieceMatch(Board board);
    }
}

