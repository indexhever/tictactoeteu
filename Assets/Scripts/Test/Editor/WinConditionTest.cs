using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;
using System.Collections;

namespace TicTacToe.Test
{
    public class WinConditionTest
    {
        [Test]
        public void Win_WhenHorizontalMatch()
        {
            int boardSize = 3;
            IObjectiveController objectiveController = NSubstitute.Substitute.For<IObjectiveController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);
            Piece currentPieceTouched = board.GetPiece(0, 1);
            Assert.AreEqual(currentPieceTouched.Behaviors[0].ToString(), "TicTacToe.NormalPieceBehavior");
            
            board.GetPiece(0, 1).Touch(PieceIcon.X);
            board.GetPiece(0, 0).Touch(PieceIcon.X);
            board.GetPiece(0, 2).Touch(PieceIcon.X);
            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);
            board.GetPiece(0, 1).Touch(PieceIcon.X);
            board.GetPiece(0, 0).Touch(PieceIcon.O);
            board.GetPiece(0, 2).Touch(PieceIcon.X);
            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);
        }

        [Test]
        public void Win_WhenVerticalMatch()
        {
            int boardSize = 3;
            IObjectiveController objectiveController = NSubstitute.Substitute.For<IObjectiveController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);
            Piece currentPieceTouched = board.GetPiece(2, 0);
            Assert.AreEqual(currentPieceTouched.Behaviors[0].ToString(), "TicTacToe.NormalPieceBehavior");
            
            board.GetPiece(0, 0).Touch(PieceIcon.X);
            board.GetPiece(1, 0).Touch(PieceIcon.X);
            board.GetPiece(2, 0).Touch(PieceIcon.X);
            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);
            board.GetPiece(0, 0).Touch(PieceIcon.X);
            board.GetPiece(1, 0).Touch(PieceIcon.O);
            board.GetPiece(2, 0).Touch(PieceIcon.X);
            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);
        }

        [Test]
        public void Win_WhenMainDiagonalMatch()
        {
            int boardSize = 3;
            IObjectiveController objectiveController = NSubstitute.Substitute.For<IObjectiveController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);
            Piece currentPieceTouched = board.GetPiece(0, 0);
            Assert.AreEqual(currentPieceTouched.Behaviors[1].ToString(), "TicTacToe.MainDiagonalPieceBehavior");

            // main diagonal with same Icon
            board.GetPiece(0, 0).Touch(PieceIcon.X);
            board.GetPiece(1, 1).Touch(PieceIcon.X);
            board.GetPiece(2, 2).Touch(PieceIcon.X);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);

            // main diagonal with one different element
            board.GetPiece(0, 0).Touch(PieceIcon.X);
            board.GetPiece(1, 1).Touch(PieceIcon.O);
            board.GetPiece(2, 2).Touch(PieceIcon.X);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);

            // reset diagonal elements
            board.GetPiece(0, 0).Touch(PieceIcon.X);
            board.GetPiece(1, 1).Touch(PieceIcon.O);
            board.GetPiece(2, 2).Touch(PieceIcon.O);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);

            // set vertical elements to be the same as currentPiece
            board.GetPiece(1, 0).Touch(PieceIcon.X);
            board.GetPiece(2, 0).Touch(PieceIcon.X);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);
        }

        [Test]
        public void Win_WhenSecondaryDiagonalMatch()
        {
            int boardSize = 3;
            IObjectiveController objectiveController = NSubstitute.Substitute.For<IObjectiveController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);
            Piece currentPieceTouched = board.GetPiece(2, 0);
            Assert.AreEqual(currentPieceTouched.Behaviors[1].ToString(), "TicTacToe.SecondaryDiagonalPieceBehavior");

            // secondary diagonal with same Icon
            board.GetPiece(2, 0).Touch(PieceIcon.X);
            board.GetPiece(1, 1).Touch(PieceIcon.X);
            board.GetPiece(0, 2).Touch(PieceIcon.X);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);

            // secondary diagonal with one different element
            board.GetPiece(2, 0).Touch(PieceIcon.X);
            board.GetPiece(1, 1).Touch(PieceIcon.O);
            board.GetPiece(0, 2).Touch(PieceIcon.X);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);

            // reset diagonal elements
            board.GetPiece(2, 0).Touch(PieceIcon.X);
            board.GetPiece(1, 1).Touch(PieceIcon.O);
            board.GetPiece(0, 2).Touch(PieceIcon.O);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);

            // set vertical elements to be the same as currentPiece
            board.GetPiece(1, 1).Touch(PieceIcon.X);
            board.GetPiece(0, 2).Touch(PieceIcon.X);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);
        }
    }
}
