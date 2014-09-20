namespace TicTacToe.Data.Contracts
{
    using TicTacToe.Models;

    public interface ITicTacToeData
    {
        IRepository<User> Users { get; }

        IRepository<Game> Games { get; }

        int SaveChanges();
    }
}
