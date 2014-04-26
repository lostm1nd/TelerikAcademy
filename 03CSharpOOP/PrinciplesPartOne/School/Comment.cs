namespace CreatingSchool
{
    using System.Collections.Generic;
    using System.Text;

    public class Comment
    {
        // Fields
        private List<string> comments;

        // Constructor
        public Comment()
        {
            this.comments = new List<string>();
        }

        // Properties
        public List<string> Comments
        {
            get { return new List<string>(this.comments); }
        }

        // Methods
        public void AddComment(string text)
        {
            this.comments.Add(text);
        }

        // Ovveride
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var comment in this.comments)
            {
                sb.AppendLine(comment);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
