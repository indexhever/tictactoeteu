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
            IGameController objectiveController = NSubstitute.Substitute.For<IGameController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);
            Piece currentPieceTouched = board.GetPieceOnRowAndColumn(0, 1);
            Assert.AreEqual(currentPieceTouched.Behaviors[0].ToString(), "TicTacToe.NormalPieceBehavior");
            Icon player1Icon = new Icon();
            Icon player2Icon = new Icon();

            board.GetPieceOnRowAndColumn(0, 1).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(0, 0).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(0, 2).PaintWithIcon(player2Icon);
            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);
            board.GetPieceOnRowAndColumn(0, 1).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(0, 0).PaintWithIcon(player1Icon);
            board.GetPieceOnRowAndColumn(0, 2).PaintWithIcon(player2Icon);
            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);
        }

        [Test]
        public void Win_WhenVerticalMatch()
        {
            int boardSize = 3;
            IGameController objectiveController = NSubstitute.Substitute.For<IGameController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);
            Piece currentPieceTouched = board.GetPieceOnRowAndColumn(2, 0);
            Assert.AreEqual(currentPieceTouched.Behaviors[0].ToString(), "TicTacToe.NormalPieceBehavior");
            Icon player1Icon = new Icon();
            Icon player2Icon = new Icon();

            board.GetPieceOnRowAndColumn(0, 0).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(1, 0).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(2, 0).PaintWithIcon(player2Icon);
            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);
            board.GetPieceOnRowAndColumn(0, 0).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(1, 0).PaintWithIcon(player1Icon);
            board.GetPieceOnRowAndColumn(2, 0).PaintWithIcon(player2Icon);
            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);
        }

        [Test]
        public void Win_WhenMainDiagonalMatch()
        {
            int boardSize = 3;
            IGameController objectiveController = NSubstitute.Substitute.For<IGameController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);
            Piece currentPieceTouched = board.GetPieceOnRowAndColumn(0, 0);
            Assert.AreEqual(currentPieceTouched.Behaviors[1].ToString(), "TicTacToe.MainDiagonalPieceBehavior");
            Icon player1Icon = new Icon();
            Icon player2Icon = new Icon();

            // main diagonal with same Icon
            board.GetPieceOnRowAndColumn(0, 0).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(1, 1).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(2, 2).PaintWithIcon(player2Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);

            // main diagonal with one different element
            board.GetPieceOnRowAndColumn(0, 0).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(1, 1).PaintWithIcon(player1Icon);
            board.GetPieceOnRowAndColumn(2, 2).PaintWithIcon(player2Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);

            // reset diagonal elements
            board.GetPieceOnRowAndColumn(0, 0).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(1, 1).PaintWithIcon(player1Icon);
            board.GetPieceOnRowAndColumn(2, 2).PaintWithIcon(player1Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);

            // set vertical elements to be the same as currentPiece
            board.GetPieceOnRowAndColumn(1, 0).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(2, 0).PaintWithIcon(player2Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);
        }

        [Test]
        public void Win_WhenSecondaryDiagonalMatch()
        {
            int boardSize = 3;
            IGameController objectiveController = NSubstitute.Substitute.For<IGameController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            Board board = new Board(boardSize, objectiveController, boardController);
            Piece currentPieceTouched = board.GetPieceOnRowAndColumn(2, 0);
            Assert.AreEqual(currentPieceTouched.Behaviors[1].ToString(), "TicTacToe.SecondaryDiagonalPieceBehavior");
            Icon player1Icon = new Icon();
            Icon player2Icon = new Icon();

            // secondary diagonal with same Icon
            board.GetPieceOnRowAndColumn(2, 0).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(1, 1).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(0, 2).PaintWithIcon(player2Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);

            // secondary diagonal with one different element
            board.GetPieceOnRowAndColumn(2, 0).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(1, 1).PaintWithIcon(player1Icon);
            board.GetPieceOnRowAndColumn(0, 2).PaintWithIcon(player2Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);

            // reset diagonal elements
            board.GetPieceOnRowAndColumn(2, 0).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(1, 1).PaintWithIcon(player1Icon);
            board.GetPieceOnRowAndColumn(0, 2).PaintWithIcon(player1Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);

            // set vertical elements to be the same as currentPiece
            board.GetPieceOnRowAndColumn(1, 1).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(0, 2).PaintWithIcon(player2Icon);

            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), true);
        }
    }
}
