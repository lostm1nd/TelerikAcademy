namespace NewsSystemWeb.Models
{
    public class Like
    {
        public int LikeId { get; set; }

        public int Value { get; set; }

        public string AuthorId { get; set; }

        public int ArticleId { get; set; }
    }
}
