using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace TicTacToe.Test
{
    public class BoardGenerationTest
    {
        /*
        [Test]
        public void NewPlayModeTestBoardGenerationTestSimplePasses()
        {
            // Use the Assert class to test conditions.
        }

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator NewPlayModeTestBoardGenerationTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            yield return null;
        }
        */

        [Test]
        public void BoardGenerationTestPasses()
        {
            int boardSize = 3;
            Board board = new Board(boardSize);
            Assert.AreNotEqual(board.GetPeace(1, 1), null);
        }

        [Test]
        public void PeacesBehaviorTestPasses()
        {
            int boardSize = 3;
            Board board = new Board(boardSize);

            Assert.AreEqual(board.GetPeace(0, 1).Behaviors.Count, 1);
            Assert.AreEqual(board.GetPeace(1, 2).Behaviors.Count, 1);
            Assert.AreEqual(board.GetPeace(2, 0).Behaviors.Count, 1);
            Assert.AreEqual(board.GetPeace(1, 1).Behaviors.Count, 2);
        }
    }
}
