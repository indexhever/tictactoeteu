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
        public void Draw_WhenNoPlayerWonAndAllPiecesTouched()
        {
            int boardSize = 3;
            IObjectiveController objectiveController = NSubstitute.Substitute.For<IObjectiveController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);
            IconType player1Icon = new IconType();
            IconType player2Icon = new IconType();

            board.GetPiece(0, 0).Touch(player1Icon);
            board.GetPiece(0, 1).Touch(player2Icon);
            board.GetPiece(0, 2).Touch(player2Icon);

            board.GetPiece(1, 0).Touch(player2Icon);
            board.GetPiece(1, 1).Touch(player1Icon);
            board.GetPiece(1, 2).Touch(player1Icon);

            board.GetPiece(2, 0).Touch(player1Icon);
            board.GetPiece(2, 1).Touch(player2Icon);
            board.GetPiece(2, 2).Touch(player2Icon);

            Piece currentPieceTouched = board.GetPiece(2, 2);
            // check if no player has won yet.
            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);
            // check if amount of eaces untouched by players has achieved the maximum (all pieces were touched)
            Assert.LessOrEqual(board.AmountPiecesUntouched, 0);
        }
    }
}
