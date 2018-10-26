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

        public void Initialize()
        {
            board = new Board(3, ObjectiveControler.Instance, this);
        }

        public void SpawnPiece(Piece piece)
        {
            GameObject newPieceGameObj = piecePool.GetObject();
            PieceComponent peaceComponent = newPieceGameObj.GetComponent<PieceComponent>();
            peaceComponent.Initialize(piece);
        }
    }
}

