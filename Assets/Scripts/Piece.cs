using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public enum PieceIcon
    {
        None,
        O,
        X
    }
    public class Piece
    {
        private List<AbstractPieceBehavior> behaviors;
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

        private IconType icon;
        public IconType Icon
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

        public List<AbstractPieceBehavior> Behaviors
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

        public Piece(List<AbstractPieceBehavior> behaviors, int row, int column, Board board)
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
                Behaviors[i].Piece = this;
            }
        }

        public bool CheckPieceMatch()
        {
            for(int i=0; i < Behaviors.Count; i++)
            {
                if (Behaviors[i].CheckPieceMatch(board))
                    return true;
            }

            return false;
        }

        public void Touch(IconType pieceIcon)
        {
            Icon = pieceIcon;
            board.DecreaseAmountPiecesUntouched();
            
        }

        // TODO: use Null object pattern
        public bool IsTouched()
        {
            return Icon != null;
        }

        public bool IsIconEqual(Piece otherPiece)
        {
            if (!IsTouched())
                return false;

            return Icon == otherPiece.Icon;
        }

        public void Reset()
        {
            Icon = null;
        }
    }
}

