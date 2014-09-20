namespace TicTacToe.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        public Game()
        {
            this.GameId = Guid.NewGuid();
            this.State = GameState.NotStarted;
            this.Board = "---------";
        }

        public Guid GameId { get; set; }

        [Column(TypeName = "char")]
        [StringLength(9)]
        public string Board { get; set; }

        [Required]
        public string PlayerOneId { get; set; }

        public User PlayerOne { get; set; }

        public string PlayerTwoId { get; set; }

        public User PlayerTwo { get; set; }

        public GameState State { get; set; }
    }
}
