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
            IGameController objectiveController = NSubstitute.Substitute.For<IGameController>();
            IBoardController boardController = NSubstitute.Substitute.For<IBoardController>();
            /*
            Board board = new Board(boardSize, objectiveController, boardController);
            Icon player1Icon = new Icon();
            Icon player2Icon = new Icon();

            board.GetPieceOnRowAndColumn(0, 0).PaintWithIcon(player1Icon);
            board.GetPieceOnRowAndColumn(0, 1).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(0, 2).PaintWithIcon(player2Icon);

            board.GetPieceOnRowAndColumn(1, 0).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(1, 1).PaintWithIcon(player1Icon);
            board.GetPieceOnRowAndColumn(1, 2).PaintWithIcon(player1Icon);

            board.GetPieceOnRowAndColumn(2, 0).PaintWithIcon(player1Icon);
            board.GetPieceOnRowAndColumn(2, 1).PaintWithIcon(player2Icon);
            board.GetPieceOnRowAndColumn(2, 2).PaintWithIcon(player2Icon);

            Piece currentPieceTouched = board.GetPieceOnRowAndColumn(2, 2);
            // check if no player has won yet.
            Assert.AreEqual(currentPieceTouched.CheckPieceMatch(), false);
            // check if amount of eaces untouched by players has achieved the maximum (all pieces were touched)
            //Assert.LessOrEqual(board.AmountPiecesUntouched, 0);
            */
        }
    }
}
