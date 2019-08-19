using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.Util;
using System;
using TicTacToe.UI;
using Zenject;

namespace TicTacToe
{
    public class GameController : MonoBehaviour, IGameController
    {        
        private Turn firstTurn;
        private Player currentPlayer;        
        [SerializeField]
        private Player[] players = new Player[2];
        private BoardComponent boardComponent;
        private HudController hudController;        

        public Player CurrentPlayer
        {
            get
            {
                currentPlayer = CurrentTurn.Player;
                return currentPlayer;
            }
            private set
            {
                currentPlayer = value;
            }
        }        
        public Turn CurrentTurn;
        
        // Events
        public delegate void ResetAction();
        public event ResetAction OnResetGame;

        [Inject]
        public void Construct(BoardComponent boardComponent, HudController hudController)
        {
            this.boardComponent = boardComponent;
            this.hudController = hudController;
        }

        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            SetupCircularTurns();
            boardComponent.Initialize();      
            ShowPlayerTurn();
        }

        private void SetupCircularTurns()
        {
            firstTurn = new Turn(players[0]);
            Turn previousTurn = firstTurn;
            Turn currentTurn = null;

            for (int i=1; i<players.Length; i++)
            {
                currentTurn = new Turn(players[i]);
                previousTurn.NextTurn = currentTurn;
                previousTurn = currentTurn;
            }

            // Setup single player game
            if (currentTurn == null)
                return;

            currentTurn.NextTurn = firstTurn;
            CurrentTurn = firstTurn;
            CurrentPlayer = CurrentTurn.Player;
        }

        public void UpdateTurn()
        {
            CurrentTurn = CurrentTurn.NextTurn;
            ShowPlayerTurn();
        }

        public void ShowPlayerTurn()
        {
            hudController.ShowMessage("Player " + (CurrentPlayer.ID) + " turn");
        }

        public void LoseGame()
        {
            hudController.ShowMessage("It is a draw!");
            boardComponent.Disable();
            Debug.Log("It is a draw");
        }

        public void WinGame()
        {
            hudController.ShowMessage("Player " + (CurrentPlayer.ID) + " win");
            boardComponent.Disable();
            Debug.Log("It is a win");
        }

        public void ResetGame()
        {
            CurrentTurn = firstTurn;
            boardComponent.Disable();
            OnResetGame();
            boardComponent.Enable();
            ShowPlayerTurn();
        }
    }
}
