using TicTacToe.Models;
namespace TicTacToe.Services.Models
{
    public class GameModel
    {
        public string GameId { get; set; }

        public string Board { get; set; }

        public string PlayerOne { get; set; }

        public string PlayerTwo { get; set; }

        public static GameModel FromGame(Game game)
        {
            return new GameModel
            {
                GameId = game.GameId.ToString(),
                Board = game.Board,
                PlayerOne = game.PlayerOneId,
                PlayerTwo = game.PlayerTwoId
            };
        }
    }
}