namespace TicTacToe.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PlayRequestModel
    {
        [Required]
        public string GameId { get; set; }

        [Range(1, 3)]
        public int Row { get; set; }

        [Range(1, 3)]
        public int Column { get; set; }
    }
}