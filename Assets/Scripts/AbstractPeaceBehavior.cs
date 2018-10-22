using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public abstract class AbstractPeaceBehavior
    {
        private Peace peace;
        public Peace Peace
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
        
        public abstract bool CheckPeaceMatch(Board board);
    }
}

