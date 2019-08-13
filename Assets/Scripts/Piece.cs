using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class Piece
    {
        private List<AbstractPieceBehavior> behaviors;
        private int row;
        private int column;
        private Board board;        
        private Icon icon;

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
        public Icon Icon
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
                Behaviors[i].Initialize(this);
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

        public void PaintWithIcon(Icon pieceIcon)
        {
            Icon = pieceIcon;
            board.DecreaseAmountPiecesUntouched();
            
        }

        public bool IsPainted()
        {
            return Icon != null;
        }

        public bool IsIconEqualToIconFromPiece(Piece otherPiece)
        {
            if (!IsPainted())
                return false;

            return Icon.Equals(otherPiece.Icon);
        }

        public void Reset()
        {
            Icon = null;
        }
    }
}

