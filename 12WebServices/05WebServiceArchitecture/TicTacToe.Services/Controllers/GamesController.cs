namespace TicTacToe.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using TicTacToe.Data;
    using TicTacToe.Data.Contracts;
    using TicTacToe.Models;
    using TicTacToe.Services.Infrastructure;
    using TicTacToe.Services.Models;
    using System.Text;
    using TicTacToe.Logic;

    [Authorize]
    public class GamesController : ApiController
    {
        private ITicTacToeData gameData;
        private IUserProvider userProvider;
        private ITicTacToeLogic gameLogic;

        public GamesController(ITicTacToeData data, IUserProvider userProvider, ITicTacToeLogic logic)
        {
            this.gameData = data;
            this.userProvider = userProvider;
            this.gameLogic = logic;
        }

        [HttpGet]
        public int GetUsersCount()
        {
            int userCount = this.gameData.Users.All().Count();
            return userCount;
        }

        [HttpGet]
        public IHttpActionResult GameStatus(string gameId)
        {
            Game actualGame = this.gameData.Games.Find(new Guid(gameId));
            if (actualGame == null)
            {
                return BadRequest("No game with this id exists.");
            }

            if (actualGame.PlayerOneId != this.userProvider.GetUserId() &&
                actualGame.PlayerTwoId != this.userProvider.GetUserId())
            {
                return BadRequest("You are not part of this game.");
            }

            return Ok(GameModel.FromGame(actualGame));
        }

        [HttpPost]
        public IHttpActionResult CreateGame()
        {
            var userId = this.userProvider.GetUserId();

            Game newGame = new Game()
            {
                PlayerOneId = userId
            };

            this.gameData.Games.Add(newGame);
            this.gameData.SaveChanges();

            return Ok(newGame.GameId);
        }

        [HttpPost]
        public IHttpActionResult JoinGame(string gameId)
        {
            var userId = this.userProvider.GetUserId();
            Guid gameGuid = new Guid(gameId);
            Game desiredGame = this.gameData.Games.Find(gameGuid);

            if (desiredGame == null)
            {
                return BadRequest("Game with the specified id does not exist.");
            }

            if (desiredGame.State != GameState.NotStarted)
            {
                return BadRequest("This game has already started.");
            }

            if (userId == desiredGame.PlayerOneId)
            {
                return BadRequest("Can not be second player in a game which you created.");
            }

            desiredGame.PlayerTwoId = userId;
            desiredGame.State = GameState.PlayerOneTurn;
            this.gameData.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult PlayTurn(PlayRequestModel request)
        {
            if (request == null || !this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var userId = this.userProvider.GetUserId();
            var gameIdGuid = new Guid(request.GameId);

            Game currentGame = this.gameData.Games.Find(gameIdGuid);
            if (currentGame == null)
            {
                return BadRequest("Game does not exist.");
            }

            if (currentGame.PlayerOneId != userId && currentGame.PlayerTwoId != userId)
            {
                return BadRequest("You are not part of this game.");
            }

            if (currentGame.State == GameState.NotStarted)
            {
                return BadRequest("Game has not started.");
            }

            if (currentGame.State == GameState.WonByPlayerOne ||
                currentGame.State == GameState.WonByPlayerTwo ||
                currentGame.State == GameState.Draw)
            {
                return BadRequest("Game has already finished.");
            }

            if (currentGame.State == GameState.PlayerOneTurn && userId != currentGame.PlayerOneId ||
                currentGame.State == GameState.PlayerTwoTurn && userId != currentGame.PlayerTwoId)
            {
                return BadRequest("It is not your turn.");
            }

            int playedPosition = (request.Row - 1) * 3 + request.Column - 1;
            if (currentGame.Board[playedPosition] != '-')
            {
                return BadRequest("Position is occupied.");
            }

            StringBuilder updatedBoard = new StringBuilder(currentGame.Board);
            updatedBoard[playedPosition] = currentGame.State == GameState.PlayerOneTurn ? 'X' : 'O';

            currentGame.Board = updatedBoard.ToString();
            this.gameData.SaveChanges();

            GameResult result = this.gameLogic.GetResult(currentGame.Board);
            switch (result)
            {
                case GameResult.WonByX:
                    currentGame.State = GameState.WonByPlayerOne;
                    break;
                case GameResult.WonByO:
                    currentGame.State = GameState.WonByPlayerTwo;
                    break;
                case GameResult.Draw:
                    currentGame.State = GameState.Draw;
                    break;
                case GameResult.NotFinished:
                    currentGame.State = currentGame.State == GameState.PlayerOneTurn ? GameState.PlayerTwoTurn : GameState.PlayerOneTurn;
                    break;
            }

            this.gameData.SaveChanges();

            return Ok(currentGame.Board);
        }
    }
}