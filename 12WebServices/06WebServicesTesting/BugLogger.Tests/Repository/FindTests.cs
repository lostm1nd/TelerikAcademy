using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using BugLogger.Data;
using BugLogger.Models;

namespace BugLogger.Tests.Repository
{
    /// <summary>
    /// Summary description for FindTests
    /// </summary>
    [TestClass]
    public class FindTests
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
        public void AddBugToRepoAndTestWhetherFindReturnsTheCorrectBug()
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
            var bugFromDb = repo.Find(bug.BugId);

            Assert.AreEqual(bug.Content, bugFromDb.Content);
        }
    }
}
