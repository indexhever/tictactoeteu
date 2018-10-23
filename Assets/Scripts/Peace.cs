using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public enum PeaceIcon
    {
        None,
        O,
        X
    }
    public class Peace
    {
        private List<AbstractPeaceBehavior> behaviors;
        private int row;
        private Board board;
        public int Row
        {
            get
            {
                return row;
            }
            private set
            {
                row = value;
            }
        }
        private int column;
        public int Column
        {
            get
            {
                return column;
            }
            private set
            {
                column = value;
            }
        }

        private PeaceIcon icon;
        public PeaceIcon Icon
        {
            get
            {
                return icon;
            }
            private set
            {
                icon = value;
            }
        }

        public List<AbstractPeaceBehavior> Behaviors
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

        public Peace(List<AbstractPeaceBehavior> behaviors, int row, int column, Board board)
        {
            Behaviors = behaviors;
            Row = row;
            Column = column;
            InitializeBehaviors();
            this.board = board;
        }

        private void InitializeBehaviors()
        {
            for(int i=0; i < Behaviors.Count; i++)
            {
                Behaviors[i].Peace = this;
            }
        }

        public bool CheckPeaceMatch()
        {
            for(int i=0; i < Behaviors.Count; i++)
            {
                if (Behaviors[i].CheckPeaceMatch(board))
                    return true;
            }

            return false;
        }

        public void Touch(PeaceIcon peaceIcon)
        {
            Icon = peaceIcon;
            board.PeaceTouched();
        }

        public bool IsTouched()
        {
            return Icon != PeaceIcon.None;
        }

        public bool IsIconEqual(Peace otherPeace)
        {
            if (!IsTouched())
                return false;

            return Icon == otherPeace.Icon;
        }
    }
}

