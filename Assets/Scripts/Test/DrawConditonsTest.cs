using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace TicTacToe
{
    public class DrawConditonsTest
    {
        [Test]
        public void DrawConditonsTestSimplePasses()
        {
            int boardSize = 3;
            Board board = new Board(boardSize);

            board.GetPeace(0, 0).Touch(PeaceIcon.O);
            board.GetPeace(0, 1).Touch(PeaceIcon.X);
            board.GetPeace(0, 2).Touch(PeaceIcon.X);

            board.GetPeace(1, 0).Touch(PeaceIcon.X);
            board.GetPeace(1, 1).Touch(PeaceIcon.O);
            board.GetPeace(1, 2).Touch(PeaceIcon.O);

            board.GetPeace(2, 0).Touch(PeaceIcon.O);
            board.GetPeace(2, 1).Touch(PeaceIcon.X);
            board.GetPeace(2, 2).Touch(PeaceIcon.X);

            Peace currentPeaceTouched = board.GetPeace(2, 2);
            Assert.AreEqual(currentPeaceTouched.CheckPeaceMatch(), false);

            Assert.LessOrEqual(board.AmountPeacesUntouched, 0);
        }
    }
}
