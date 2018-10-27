﻿using System.Collections;
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
