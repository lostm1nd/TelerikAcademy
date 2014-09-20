namespace BugLogger.Tests.Repository
{
    using System;
    using System.Transactions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using BugLogger.Data;
    using BugLogger.Models;

    [TestClass]
    public class UpdateTests
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
        public void AddBugAndUpdateItThenCheckWhetherTheUpdatesAreReflected()
        {
            //arrange
            var context = new BugLoggerDbContext();
            var repo = new BugsRepository(context);

            var bug = new Bug
            {
                Content = "New bug"
            };

            //act
            repo.Add(bug);
            repo.SaveChanges();

            bug.Status = BugStatus.Assigned;
            repo.SaveChanges();

            //assert
            var bugFromDb = repo.Find(bug.BugId);

            Assert.AreEqual(BugStatus.Assigned, bugFromDb.Status);
        }
    }
}
