namespace BugLogger.Tests.Repository
{
    using System;
    using System.Linq;
    using System.Transactions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BugLogger.Data;
    using BugLogger.Models;

    [TestClass]
    public class AllTests
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
        public void AddThreeBugsToRepoAndCheckWhetherAllReturnsTheCorrectBugs()
        {
            //arrange
            var context = new BugLoggerDbContext();
            var repo = new BugsRepository(context);

            var countInDbBeforeAddingThreeBugs = context.Bugs.Count();

            var bug1 = new Bug
            {
                Content = "test bug 1"
            };

            var bug2 = new Bug
            {
                Content = "test bug 2"
            };

            var bug3 = new Bug
            {
                Content = "test bug 3"
            };

            //act
            context.Bugs.Add(bug1);
            context.Bugs.Add(bug2);
            context.Bugs.Add(bug3);
            context.SaveChanges();

            //assert
            var countInDbAfterAddingThreeBugs = repo.All().ToList().Count;

            Assert.AreEqual(3, countInDbAfterAddingThreeBugs - countInDbBeforeAddingThreeBugs);
        }
    }
}
