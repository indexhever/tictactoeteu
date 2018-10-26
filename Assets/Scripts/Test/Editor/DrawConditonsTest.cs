using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;

namespace TicTacToe.Test
{
    public class DrawConditonsTest
    {
        [Test]
        public void Draw_WhenNoPlayerWonAndAllPeacesTouched()
        {
            int boardSize = 3;
            IObjectiveController objectiveController = NSubstitute.Substitute.For<IObjectiveController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);

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
            // check if no player has won yet.
            Assert.AreEqual(currentPeaceTouched.CheckPeaceMatch(), false);
            // check if amount of eaces untouched by players has achieved the maximum (all peaces were touched)
            Assert.LessOrEqual(board.AmountPeacesUntouched, 0);
        }
    }
}
