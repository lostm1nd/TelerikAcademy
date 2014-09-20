namespace BugLogger.Data
{
    using System.Data.Entity;

    using BugLogger.Data.Migrations;
    using BugLogger.Models;

    public class BugLoggerDbContext : DbContext
    {
        public BugLoggerDbContext()
            : base("BugLogger")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggerDbContext, Configuration>());
        }

        public IDbSet<Bug> Bugs { get; set; }
    }
}
