namespace TicTacToe.Models
{
    public enum GameState
    {
        NotStarted = 0,
        PlayerOneTurn = 1,
        PlayerTwoTurn = 2,
        WonByPlayerOne = 3,
        WonByPlayerTwo = 4,
        Draw = 5
    }
}
