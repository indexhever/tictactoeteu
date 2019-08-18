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
        private PieceFactory pieceFactory;

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
            pieceFactory = new PieceFactory(this);

            Initialize(boardSize);
        }

        private void Initialize(int boardSize)
        {
            BoardSize = boardSize;
            pieces = new Piece[boardSize, boardSize];

            CreatePieces();
            amountPiecesUntouched = SetupAmountPiecesUntouched();
        }

        private void CreatePieces()
        {
            for(int row=0; row<BoardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    pieces[row, column] = pieceFactory.CreateOnRowAndColumn(row, column);
                    boardController.SpawnPiece(pieces[row, column]);
                }
            }
        }        

        public Piece GetPieceOnRowAndColumn(int row, int column)
        {
            return pieces[row, column];
        }

        public void DecreaseAmountPiecesUntouched()
        {
            --amountPiecesUntouched;

            DrawGameIfAllPiecesTouched();
        }        

        private void DrawGameIfAllPiecesTouched()
        {
            if (amountPiecesUntouched > 0)
                return;

            gameController.LoseGame();
        }

        public void Reset()
        {
            amountPiecesUntouched = SetupAmountPiecesUntouched();
        }

        private int SetupAmountPiecesUntouched()
        {
            return boardSize * boardSize;
        }
    }
}
