namespace BugLogger.Models
{
    using System;

    public class Bug
    {
        public int BugId { get; set; }

        public string Content { get; set; }

        public DateTime? LogDate { get; set; }

        public BugStatus Status { get; set; }
    }
}
