using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class Board
    {
        private int boardSize;
        private Peace[,] peaces;

        public Board(int boardSize)
        {
            this.boardSize = boardSize;
            peaces = new Peace[boardSize,boardSize];

            InitializePositions();
        }

        private void InitializePositions()
        {
            for(int i=0; i<boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    peaces[i, j] = CreatePeace(i, j);
                }
            }
        }

        private Peace CreatePeace(int row, int column)
        {
            List<PeaceBehavior> peaceBehaviors = CreatePeaceBehavior(row, column);
            Peace newPeace = new Peace(peaceBehaviors);
            return newPeace;
        }

        private List<PeaceBehavior> CreatePeaceBehavior(int row, int column)
        {
            List<PeaceBehavior> peaceBehaviors = new List<PeaceBehavior>();
            if(!IsMainDiagonalPeace(row, column) && !IsSecondaryDiagonalPeace(row, column))
            {
                peaceBehaviors.Add(new PeaceBehavior());
                return peaceBehaviors;
            }

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
            return row + column == boardSize - 1;
        }

        public Peace GetPeace(int row, int column)
        {
            return peaces[row, column];
        }
    }
}
