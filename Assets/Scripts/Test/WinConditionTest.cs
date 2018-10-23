using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace TicTacToe.Test
{
    public class WinConditionTest
    {
        [Test]
        public void NormalPeaceWinConditionPasses()
        {
            int boardSize = 3;
            Board board = new Board(boardSize);
            Peace currentPeaceTouched = board.GetPeace(0, 1);
            Assert.AreEqual(currentPeaceTouched.Behaviors[0].ToString(), "TicTacToe.NormalPeaceBehavior");

            board.GetPeace(0, 1).Touch(PeaceIcon.X);
            board.GetPeace(0, 0).Touch(PeaceIcon.X);
            board.GetPeace(0, 2).Touch(PeaceIcon.X);

            Assert.AreEqual(currentPeaceTouched.CheckPeaceMatch(), true);

            board.GetPeace(0, 1).Touch(PeaceIcon.X);
            board.GetPeace(0, 0).Touch(PeaceIcon.O);
            board.GetPeace(0, 2).Touch(PeaceIcon.X);

            Assert.AreEqual(currentPeaceTouched.CheckPeaceMatch(), false);
        }

        [Test]
        public void MainDiagonalPeaceWinConditionPasses()
        {
            int boardSize = 3;
            Board board = new Board(boardSize);
            Peace currentPeaceTouched = board.GetPeace(0, 0);
            Assert.AreEqual(currentPeaceTouched.Behaviors[1].ToString(), "TicTacToe.MainDiagonalPeaceBehavior");

            // main diagonal with same Icon
            board.GetPeace(0, 0).Touch(PeaceIcon.X);
            board.GetPeace(1, 1).Touch(PeaceIcon.X);
            board.GetPeace(2, 2).Touch(PeaceIcon.X);

            Assert.AreEqual(currentPeaceTouched.CheckPeaceMatch(), true);

            // main diagonal with one different element
            board.GetPeace(0, 0).Touch(PeaceIcon.X);
            board.GetPeace(1, 1).Touch(PeaceIcon.O);
            board.GetPeace(2, 2).Touch(PeaceIcon.X);

            Assert.AreEqual(currentPeaceTouched.CheckPeaceMatch(), false);

            // reset diagonal elements
            board.GetPeace(0, 0).Touch(PeaceIcon.X);
            board.GetPeace(1, 1).Touch(PeaceIcon.O);
            board.GetPeace(2, 2).Touch(PeaceIcon.O);

            Assert.AreEqual(currentPeaceTouched.CheckPeaceMatch(), false);

            // set vertical elements to be the same as currentPeace
            board.GetPeace(1, 0).Touch(PeaceIcon.X);
            board.GetPeace(2, 0).Touch(PeaceIcon.X);

            Assert.AreEqual(currentPeaceTouched.CheckPeaceMatch(), true);
        }

        [Test]
        public void SecondaryDiagonalPeaceWinConditionPasses()
        {
            int boardSize = 3;
            Board board = new Board(boardSize);
            Peace currentPeaceTouched = board.GetPeace(2, 0);
            Assert.AreEqual(currentPeaceTouched.Behaviors[1].ToString(), "TicTacToe.SecondaryDiagonalPeaceBehavior");

            // secondary diagonal with same Icon
            board.GetPeace(2, 0).Touch(PeaceIcon.X);
            board.GetPeace(1, 1).Touch(PeaceIcon.X);
            board.GetPeace(0, 2).Touch(PeaceIcon.X);

            Assert.AreEqual(currentPeaceTouched.CheckPeaceMatch(), true);

            // secondary diagonal with one different element
            board.GetPeace(2, 0).Touch(PeaceIcon.X);
            board.GetPeace(1, 1).Touch(PeaceIcon.O);
            board.GetPeace(0, 2).Touch(PeaceIcon.X);

            Assert.AreEqual(currentPeaceTouched.CheckPeaceMatch(), false);

            // reset diagonal elements
            board.GetPeace(2, 0).Touch(PeaceIcon.X);
            board.GetPeace(1, 1).Touch(PeaceIcon.O);
            board.GetPeace(0, 2).Touch(PeaceIcon.O);

            Assert.AreEqual(currentPeaceTouched.CheckPeaceMatch(), false);

            // set vertical elements to be the same as currentPeace
            board.GetPeace(1, 1).Touch(PeaceIcon.X);
            board.GetPeace(0, 2).Touch(PeaceIcon.X);

            Assert.AreEqual(currentPeaceTouched.CheckPeaceMatch(), true);
        }
    }
}
