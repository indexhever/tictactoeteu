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
        ObjectPoolController peacePool;

        public void Initialize()
        {
            board = new Board(3, ObjectiveControler.Instance, this);
        }

        public void SpawnPeace(Peace peace)
        {
            GameObject newPeaceGameObj = peacePool.GetObject();
            PeaceComponent peaceComponent = newPeaceGameObj.GetComponent<PeaceComponent>();
            peaceComponent.Initialize(peace);
        }
    }
}

