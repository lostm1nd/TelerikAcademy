namespace BugLogger.Tests.Repository
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BugLogger.Data;
    using BugLogger.Models;
    using System.Transactions;

    [TestClass]
    public class AddTests
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
        public void AddBugToRepoAndCheckWhetherTheContentIsCorrect()
        {
            //arrange
            var context = new BugLoggerDbContext();
            var repo = new BugsRepository(context);

            var bug = new Bug
            {
                Content = "Please fix my blog"
            };

            //act
            repo.Add(bug);
            context.SaveChanges();

            //assert
            var bugFromDb = context.Bugs.Find(bug.BugId);

            Assert.AreEqual(bug.Content, bugFromDb.Content);
        }

        [TestMethod]
        public void AddBugToRepoAndCheckWhetherTheStatusIsPending()
        {
            //arrange
            var context = new BugLoggerDbContext();
            var repo = new BugsRepository(context);

            var bug = new Bug
            {
                Content = "Status should be pending"
            };

            //act
            repo.Add(bug);
            context.SaveChanges();

            //assert
            var bugFromDb = context.Bugs.Find(bug.BugId);

            Assert.AreEqual(BugStatus.Pending, bugFromDb.Status);
        }

        [TestMethod]
        public void AddBugToRepoWithNoDataShouldNotHaveADate()
        {
            //arrange
            var context = new BugLoggerDbContext();
            var repo = new BugsRepository(context);

            var bug = new Bug
            {
                Content = "Status should be pending"
            };

            //act
            repo.Add(bug);
            context.SaveChanges();

            //assert
            var bugFromDb = context.Bugs.Find(bug.BugId);

            Assert.AreSame(null, bugFromDb.LogDate);
            Assert.AreEqual(bug.LogDate, bugFromDb.LogDate);
        }
    }
}
