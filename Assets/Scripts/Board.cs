using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class Board
    {
        IObjectiveController objectiveController;
        public IObjectiveController ObjectiveController
        {
            get
            {
                return objectiveController;
            }
            set
            {
                objectiveController = value;
            }
        }
        private int amountPeacesUntouched;
        public int AmountPeacesUntouched
        {
            get
            {
                return amountPeacesUntouched;
            }
            private set
            {
                amountPeacesUntouched = value;
            }
        }
        private int boardSize;
        public int BoardSize
        {
            get
            {
                return boardSize;
            }
            private set
            {
                boardSize = value;
            }
        }
        private Peace[,] peaces;

        public Board(int boardSize, IObjectiveController objectiveController)
        {
            
            ObjectiveController = objectiveController;
            Initialize(boardSize);
        }

        private void Initialize(int boardSize)
        {
            BoardSize = boardSize;
            peaces = new Peace[boardSize, boardSize];

            InitializePositions();
            AmountPeacesUntouched = boardSize * boardSize;
            ObjectiveController = objectiveController;
        }

        private void InitializePositions()
        {
            for(int i=0; i<BoardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    peaces[i, j] = CreatePeace(i, j);
                }
            }
        }

        private Peace CreatePeace(int row, int column)
        {
            List<AbstractPeaceBehavior> peaceBehaviors = CreatePeaceBehavior(row, column);
            Peace newPeace = new Peace(peaceBehaviors, row, column, this);
            return newPeace;
        }

        private List<AbstractPeaceBehavior> CreatePeaceBehavior(int row, int column)
        {
            List<AbstractPeaceBehavior> peaceBehaviors = new List<AbstractPeaceBehavior>();
            peaceBehaviors.Add(new NormalPeaceBehavior());

            if (!IsMainDiagonalPeace(row, column) && !IsSecondaryDiagonalPeace(row, column))
                return peaceBehaviors;

            if (IsMainDiagonalPeace(row, column))
                peaceBehaviors.Add(new MainDiagonalPeaceBehavior());

            if (IsSecondaryDiagonalPeace(row, column))
                peaceBehaviors.Add(new SecondaryDiagonalPeaceBehavior());

            return peaceBehaviors;
        }

        private bool IsMainDiagonalPeace(int row, int column)
        {
            return row == column;
        }

        private bool IsSecondaryDiagonalPeace(int row, int column)
        {
            return row + column == BoardSize - 1;
        }

        public Peace GetPeace(int row, int column)
        {
            return peaces[row, column];
        }

        public void PeaceTouched()
        {
            --AmountPeacesUntouched;

            // call draw
            if (AmountPeacesUntouched <= 0)
            {
                ObjectiveController.LoseGame();
            }            
        }
    }
}
