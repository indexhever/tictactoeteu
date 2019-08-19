using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Util;
using Zenject;

namespace TicTacToe
{
    public class BoardComponent : MonoBehaviour, IBoardController
    {
        private Board board;
        [SerializeField]
        private float offsetBetweenPieces;
        [SerializeField]
        private int boardSize;
        private GameController gameController;
        private PieceComponent.Factory pieceComponentFactory;
        private Board.Factory boardFactory;

        [Inject]
        public void Construct(GameController gameController, PieceComponent.Factory pieceFactory, Board.Factory boardFactory)
        {
            this.gameController = gameController;
            this.pieceComponentFactory = pieceFactory;
            this.boardFactory = boardFactory;
        }

        public void Initialize()
        {
            board = boardFactory.Create(boardSize);
            board.Initialize();

            gameController.OnResetGame += board.Reset;
        }

        public void SpawnPiece(Piece piece)
        {
            PieceComponent pieceComponent = pieceComponentFactory.Create(piece);
            pieceComponent.Initialize(transform.position, offsetBetweenPieces);
            pieceComponent.transform.SetParent(transform);

            // Set Reset event
            gameController.OnResetGame += piece.Reset;
            gameController.OnResetGame += pieceComponent.Reset;
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }
    }
}

