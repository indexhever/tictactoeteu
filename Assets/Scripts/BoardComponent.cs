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
        ObjectPoolController piecePool;
        [SerializeField]
        private float offsetBetweenPieces;
        [SerializeField]
        private int boardSize;
        private GameController gameController;
        private PieceComponent.Factory pieceComponentFactory;

        [Inject]
        public void Construct(GameController gameController, PieceComponent.Factory pieceFactory)
        {
            this.gameController = gameController;
            this.pieceComponentFactory = pieceFactory;
        }

        public void Initialize()
        {
            board = new Board(boardSize, gameController, this);
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

