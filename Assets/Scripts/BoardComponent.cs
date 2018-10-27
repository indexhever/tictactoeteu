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
            board = new Board(boardSize, ObjectiveControler.Instance, this);
        }

        public void SpawnPiece(Piece piece)
        {
            GameObject newPieceGameObj = piecePool.GetObject();
            PieceComponent peaceComponent = newPieceGameObj.GetComponent<PieceComponent>();
            peaceComponent.Initialize(piece, transform.position, offsetBetweenPieces);
        }
    }
}

