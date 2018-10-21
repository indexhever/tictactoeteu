using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class PeaceBehavior
    {
        public virtual bool CheckPeaceMatch(Board board)
        {
            return true;
        }
    }
}

