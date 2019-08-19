using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TicTacToe
{
    public class Board
    {
        private GameController gameController;
        private BoardComponent boardController;
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
        
        [Inject]
        public Board(
            int boardSize, 
            GameController gameController, 
            BoardComponent boardController,
            PieceFactory pieceFactory)
        {
            BoardSize = boardSize;
            pieces = new Piece[boardSize, boardSize];
            this.gameController = gameController;
            this.boardController = boardController;
            this.pieceFactory = pieceFactory;            
        }

        public void Initialize()
        {
            CreatePieces();
            amountPiecesUntouched = SetupAmountPiecesUntouched();
        }

        private void CreatePieces()
        {
            for(int row=0; row<BoardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    pieces[row, column] = pieceFactory.Create(this, row, column);
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

        public class Factory : PlaceholderFactory<int, Board>
        {

        }
    }
}
