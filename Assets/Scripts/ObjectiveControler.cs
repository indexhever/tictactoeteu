using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Util;
using System;

namespace TicTacToe
{
    public class ObjectiveControler : Singleton<ObjectiveControler>, IObjectiveController
    {
        [SerializeField]
        private BoardComponent boardComponent;
        [SerializeField]
        private Player[] players = new Player[2];
        private Player currentPlayer;
        public Player CurrentPlayer
        {
            get
            {
                if (currentPlayerID == 0)
                {
                    currentPlayer = players[currentPlayerID];
                    currentPlayerID++;
                }
                else
                {
                    currentPlayer = players[currentPlayerID];
                    currentPlayerID = 0;
                }

                return currentPlayer;
            }
            set
            {
                currentPlayer = value;
            }
        }
        private int currentPlayerID;

        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            boardComponent.Initialize();
        }

        public void LoseGame()
        {
            Debug.Log("It is a draw");
        }

        public void WinGame()
        {
            Debug.Log("It is a win");
        }
    }
}
