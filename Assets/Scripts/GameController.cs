using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Util;
using System;
using TicTacToe.UI;

namespace TicTacToe
{
    public class GameController : Singleton<GameController>, IGameController
    {
        [SerializeField]
        private BoardComponent boardComponent;
        // Player
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
                ShowPlayerTurn();
                return currentPlayer;
            }
            set
            {
                currentPlayer = value;
            }
        }
        private int currentPlayerID;
        // UI
        [SerializeField]
        private HudController hudController;
        // Events
        public delegate void ResetAction();
        public event ResetAction OnResetGame;

        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            boardComponent.Initialize();
            ShowPlayerTurn();
        }

        public void ShowPlayerTurn()
        {
            hudController.ShowMessage("Player " + (currentPlayerID + 1) + " turn");
        }

        public void LoseGame()
        {
            hudController.ShowMessage("It is a draw!");
            boardComponent.Disable();
            Debug.Log("It is a draw");
        }

        public void WinGame()
        {
            hudController.ShowMessage("Player " + (currentPlayerID) + " win");
            boardComponent.Disable();
            Debug.Log("It is a win");
        }

        public void ResetGame()
        {
            currentPlayerID = 0;
            boardComponent.Disable();
            OnResetGame();
            boardComponent.Enable();
            ShowPlayerTurn();
        }
    }
}
