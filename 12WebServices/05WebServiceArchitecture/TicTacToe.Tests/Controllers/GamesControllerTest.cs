namespace TicTacToe.Tests.Controllers
{
    using System;
    using System.Web.Mvc;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TicTacToe.Services;
    using TicTacToe.Services.Controllers;
    using TicTacToe.Models;
    using Moq;
    using TicTacToe.Services.Infrastructure;
    using TicTacToe.Logic;
    using TicTacToe.Data.Contracts;
    using TicTacToe.Services.Models;

    [TestClass]
    public class GamesControllerTest
    {
        [TestMethod]
        public void WhenPlayerOnePlaysGameStateChangesToPlayerTwoTurn()
        {
            // Arrange
            string playerOneId = "test@test.com";
            var gameId = Guid.NewGuid();
            Game gameMock = new Game
            {
                GameId = gameId,
                PlayerOneId = playerOneId,
                State = GameState.PlayerOneTurn
            };

            var repoMock = new Mock<ITicTacToeData>();
            repoMock.Setup(x => x.Games.Find(It.IsAny<object>())).Returns(gameMock);

            var userProviderMock = new Mock<IUserProvider>();
            userProviderMock.Setup(x => x.GetUserId()).Returns(playerOneId);

            var gameLogicMock = new Mock<ITicTacToeLogic>();
            gameLogicMock.Setup(x => x.GetResult(It.IsAny<string>())).Returns(GameResult.NotFinished);

            var gamesController = new GamesController(repoMock.Object, userProviderMock.Object, gameLogicMock.Object);

            // Act
            gamesController.PlayTurn(new PlayRequestModel
            {
                GameId = gameId.ToString(),
                Row = 1,
                Column = 2
            });

            // Assert
            Assert.AreEqual(GameState.PlayerTwoTurn, gameMock.State);
        }
    }
}
