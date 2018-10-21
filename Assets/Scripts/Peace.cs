using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class Peace
    {
        private List<PeaceBehavior> behaviors;

        public List<PeaceBehavior> Behaviors
        {
            get
            {
                return behaviors;
            }

            private set
            {
                behaviors = value;
            }
        }

        public Peace(List<PeaceBehavior> behaviors)
        {
            Behaviors = behaviors;
        }
    }
}

