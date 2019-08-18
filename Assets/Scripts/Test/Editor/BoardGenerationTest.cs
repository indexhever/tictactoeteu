using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEditor;
using NSubstitute;
using System.Collections;

namespace TicTacToe.Test
{
    public class BoardGenerationTest
    {
        [Test]
        public void BoardGenerationWorks_WhenItIsInitiated()
        {
            int boardSize = 3;
            IGameController objectiveController = NSubstitute.Substitute.For<IGameController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);

            Assert.AreNotEqual(board.GetPieceOnRowAndColumn(1, 1), null);
        }

        [Test]
        public void PiecesWithCorrectBehavior_AfterInitialized()
        {
            int boardSize = 3;
            IGameController objectiveController = NSubstitute.Substitute.For<IGameController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);

            Assert.AreEqual(board.GetPieceOnRowAndColumn(0, 1).Behaviors.Count, 1);
            Assert.AreEqual(board.GetPieceOnRowAndColumn(1, 2).Behaviors.Count, 1);
            Assert.AreEqual(board.GetPieceOnRowAndColumn(2, 0).Behaviors.Count, 2);
            Assert.AreEqual(board.GetPieceOnRowAndColumn(1, 1).Behaviors.Count, 3);
        }
    }
}
