namespace TicTacToe.Tests.Logic
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToe.Logic;

    [TestClass]
    public class TicTacToeLogicTests
    {
        [TestMethod]
        public void WhenThereAreNoFreePositionsAnNoOneWinsGameShouldBeDraw()
        {
            string board1 = "XXO" +
                            "OXX" +
                            "XOO";

            string board2 = "XOX" +
                            "XXO" +
                            "OXO";

            string board3 = "OXO" +
                            "XXO" +
                            "XOX";

            ITicTacToeLogic logic = new TicTacToeLogic();

            Assert.AreEqual(GameResult.Draw, logic.GetResult(board1));
            Assert.AreEqual(GameResult.Draw, logic.GetResult(board2));
            Assert.AreEqual(GameResult.Draw, logic.GetResult(board3));
        }

        [TestMethod]
        public void WhenThereAreThreeXPlayerOneWins()
        {
            string board1 = "XXO" +
                            "OXO" +
                            "OXX";

            string board2 = "XXO" +
                            "XOX" +
                            "XXO";

            string board3 = "XXX" +
                            "XOO" +
                            "OXX";

            string board4 = "XOX" +
                            "OXO" +
                            "XOX";

            ITicTacToeLogic logic = new TicTacToeLogic();

            Assert.AreEqual(GameResult.WonByX, logic.GetResult(board1));
            Assert.AreEqual(GameResult.WonByX, logic.GetResult(board2));
            Assert.AreEqual(GameResult.WonByX, logic.GetResult(board3));
            Assert.AreEqual(GameResult.WonByX, logic.GetResult(board4));
        }

        [TestMethod]
        public void WhenThereAreThreeOPlayerTwoWins()
        {
            string board1 = "XX-" +
                            "OOO" +
                            "X-X";

            string board2 = "XOX" +
                            "-OX" +
                            "-O-";

            string board3 = "XXO" +
                            "XO-" +
                            "OX-";

            string board4 = "OXX" +
                            "-O-" +
                            "X-O";

            ITicTacToeLogic logic = new TicTacToeLogic();

            Assert.AreEqual(GameResult.WonByO, logic.GetResult(board1));
            Assert.AreEqual(GameResult.WonByO, logic.GetResult(board2));
            Assert.AreEqual(GameResult.WonByO, logic.GetResult(board3));
            Assert.AreEqual(GameResult.WonByO, logic.GetResult(board4));
        }

        [TestMethod]
        public void WhenThereAreMorePositionAndNoPlayerWinsTheGameIsNotFinished()
        {
            string board1 = "XX-" +
                            "O-O" +
                            "--X";

            string board2 = "XOX" +
                            "--X" +
                            "-O-";

            string board3 = "X--" +
                            "-O-" +
                            "OX-";

            string board4 = "OXX" +
                            "---" +
                            "X-O";

            ITicTacToeLogic logic = new TicTacToeLogic();

            Assert.AreEqual(GameResult.NotFinished, logic.GetResult(board1));
            Assert.AreEqual(GameResult.NotFinished, logic.GetResult(board2));
            Assert.AreEqual(GameResult.NotFinished, logic.GetResult(board3));
            Assert.AreEqual(GameResult.NotFinished, logic.GetResult(board4));
        }
    }
}
