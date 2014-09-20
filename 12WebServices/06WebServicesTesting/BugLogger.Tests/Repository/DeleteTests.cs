namespace BugLogger.Tests.Repository
{
    using System;
    using System.Linq;
    using System.Transactions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BugLogger.Data;
    using BugLogger.Models;

    [TestClass]
    public class DeleteTests
    {
        private static TransactionScope transaction;

        [TestInitialize]
        public void TestInitiliaze()
        {
            transaction = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void AddBugToRepoAndTestWhetherDeleteByIdDeletesTheBug()
        {
            //arrange
            var context = new BugLoggerDbContext();
            var repo = new BugsRepository(context);

            var bug = new Bug
            {
                Content = "Please fix my blog"
            };

            //act
            context.Bugs.Add(bug);
            context.SaveChanges();

            //assert
            repo.Delete(bug.BugId);
            context.SaveChanges();

            var bugInDb = context.Bugs.FirstOrDefault(b => b.BugId == bug.BugId);

            Assert.AreEqual(null, bugInDb);
        }

        [TestMethod]
        public void AddBugToRepoAndTestWhetherDeleteByEntityDeletesTheBug()
        {
            //arrange
            var context = new BugLoggerDbContext();
            var repo = new BugsRepository(context);

            var bug = new Bug
            {
                Content = "Please fix my blog"
            };

            //act
            context.Bugs.Add(bug);
            context.SaveChanges();

            //assert
            repo.Delete(bug);
            context.SaveChanges();

            var bugInDb = context.Bugs.Find(bug.BugId);

            Assert.AreEqual(null, bugInDb);
        }
    }
}
