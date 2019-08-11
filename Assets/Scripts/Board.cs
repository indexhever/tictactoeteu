using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class Board
    {
        private IGameController gameController;
        private IBoardController boardController;
        private int amountPiecesUntouched;
        private int boardSize;
        private Piece[,] pieces;

        public int BoardSize
        {
            get
            {
                return boardSize;
            }
            private set
            {
                boardSize = value;
            }
        }
        

        public Board(int boardSize, IGameController gameController, IBoardController boardController)
        {            
            this.gameController = gameController;
            this.boardController = boardController;
            Initialize(boardSize);
        }

        private void Initialize(int boardSize)
        {
            BoardSize = boardSize;
            pieces = new Piece[boardSize, boardSize];

            InitializePositions();
            amountPiecesUntouched = SetupAmountPiecesUntouched();
        }

        private void InitializePositions()
        {
            for(int i=0; i<BoardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    pieces[i, j] = CreatePiece(i, j);
                    boardController.SpawnPiece(pieces[i, j]);
                }
            }
        }

        private Piece CreatePiece(int row, int column)
        {
            List<AbstractPieceBehavior> pieceBehaviors = CreatePieceBehavior(row, column);
            Piece newPiece = new Piece(pieceBehaviors, row, column, this);
            return newPiece;
        }

        private List<AbstractPieceBehavior> CreatePieceBehavior(int row, int column)
        {
            List<AbstractPieceBehavior> pieceBehaviors = new List<AbstractPieceBehavior>();
            pieceBehaviors.Add(new NormalPieceBehavior());

            if (!IsMainDiagonalPiece(row, column) && !IsSecondaryDiagonalPiece(row, column))
                return pieceBehaviors;

            if (IsMainDiagonalPiece(row, column))
                pieceBehaviors.Add(new MainDiagonalPieceBehavior());

            if (IsSecondaryDiagonalPiece(row, column))
                pieceBehaviors.Add(new SecondaryDiagonalPieceBehavior());

            return pieceBehaviors;
        }

        private bool IsMainDiagonalPiece(int row, int column)
        {
            return row == column;
        }

        private bool IsSecondaryDiagonalPiece(int row, int column)
        {
            return row + column == BoardSize - 1;
        }

        public Piece GetPiece(int row, int column)
        {
            return pieces[row, column];
        }

        public void PieceTouched()
        {
            --amountPiecesUntouched;

            // call draw
            if (amountPiecesUntouched <= 0)
            {
                gameController.LoseGame();
            }            
        }

        private int SetupAmountPiecesUntouched()
        {
            return boardSize * boardSize;
        }

        public void Reset()
        {
            amountPiecesUntouched = SetupAmountPiecesUntouched();
        }
    }
}
