using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class Turn
    {
        public Player Player;
        public Turn NextTurn;

        public Turn (Player player)
        {
            Player = player;
        }
    }
}
