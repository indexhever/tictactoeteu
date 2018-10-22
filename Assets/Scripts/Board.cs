using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class Board
    {
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

        public Board(int boardSize)
        {
            BoardSize = boardSize;
            peaces = new Peace[boardSize,boardSize];

            InitializePositions();
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
            Peace newPeace = new Peace(peaceBehaviors, row, column);
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
    }
}
