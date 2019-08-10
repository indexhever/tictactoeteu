using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Util;

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

        public void Initialize()
        {
            board = new Board(boardSize, GameController.Instance, this);
            GameController.Instance.OnResetGame += board.Reset;
        }

        public void SpawnPiece(Piece piece)
        {
            GameObject newPieceGameObj = piecePool.GetObject();
            PieceComponent pieceComponent = newPieceGameObj.GetComponent<PieceComponent>();
            pieceComponent.Initialize(piece, transform.position, offsetBetweenPieces);
            newPieceGameObj.transform.SetParent(transform);

            // Set Reset event
            GameController.Instance.OnResetGame += piece.Reset;
            GameController.Instance.OnResetGame += pieceComponent.Reset;
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

