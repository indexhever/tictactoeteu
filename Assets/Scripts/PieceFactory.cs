using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TicTacToe
{
    public class PieceFactory : PlaceholderFactory<Board, int, int, Piece>
    {
        private int row;
        private int column;
        private Board board;

        public override Piece Create(Board board, int row, int column)
        {
            this.board = board;
            return CreateOnRowAndColumn(row, column);
        }

        public Piece CreateOnRowAndColumn(int row, int column)
        {
            Initialize(row, column);
            List<AbstractPieceBehavior> pieceBehaviors = CreatePieceBehaviors();
            Piece newPiece = new Piece(pieceBehaviors, row, column, board);

            return newPiece;
        }

        private void Initialize(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        private List<AbstractPieceBehavior> CreatePieceBehaviors()
        {
            List<AbstractPieceBehavior> pieceBehaviors = new List<AbstractPieceBehavior>();
            pieceBehaviors.Add(new NormalPieceBehavior());

            if (!IsMainDiagonalPiece() && !IsSecondaryDiagonalPiece())
                return pieceBehaviors;

            if (IsMainDiagonalPiece())
                pieceBehaviors.Add(new MainDiagonalPieceBehavior());

            if (IsSecondaryDiagonalPiece())
                pieceBehaviors.Add(new SecondaryDiagonalPieceBehavior());

            return pieceBehaviors;
        }

        private bool IsMainDiagonalPiece()
        {
            return row == column;
        }

        private bool IsSecondaryDiagonalPiece()
        {
            return row + column == board.BoardSize - 1;
        }
    }
}
