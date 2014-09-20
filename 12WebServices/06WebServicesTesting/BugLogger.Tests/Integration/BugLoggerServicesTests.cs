namespace BugLogger.Tests.Integration
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Net;

    using BugLogger.Models;
    using BugLogger.Data;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;

    [TestClass]
    public class BugLoggerServicesTests
    {
        public const string BugLoggerServicesUrl = "http://localhost:21878/api";

        [TestMethod]
        public void TestGetRequestWhenThereIsDataInRepoShouldReturnThatData()
        {
            // arrange
            Bug[] bugs =
            {
                new Bug {Content = "Bug1"},
                new Bug {Content = "Bug2"},
                new Bug {Content = "Bug3"}
            };

            var repoMock = new Mock<IRepository<Bug>>();
            repoMock.Setup(repo => repo.All()).Returns(bugs.AsQueryable());

            var server = new InMemoryHttpServer<Bug>(BugLoggerServicesUrl, repoMock.Object);

            // act
            var response = server.CreateGetRequest("/bugs");

            // assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestPostRequestWhenBugIsValidShouldReturn201Created()
        {
            // arrange
            Bug bug = new Bug { BugId = 2014, Content = "Valid bug" };

            var repoMock = new Mock<IRepository<Bug>>();

            var server = new InMemoryHttpServer<Bug>(BugLoggerServicesUrl, repoMock.Object);

            // act
            var response = server.CreatePostRequest("/bugs", bug);

            // assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(response.Headers.Location, BugLoggerServicesUrl + "/bugs/" + bug.BugId);
        }

        [TestMethod]
        public void TestPostRequestWhenBugIsInvalidShouldReturnBadRequest()
        {
            // arrange
            Bug bug = new Bug { BugId = 2014 };

            var repoMock = new Mock<IRepository<Bug>>();

            var server = new InMemoryHttpServer<Bug>(BugLoggerServicesUrl, repoMock.Object);

            // act
            var response = server.CreatePostRequest("/bugs", bug);

            // assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestPutRequestWhenBugIsValidShouldUpdateBug()
        {
            // arrange
            Bug bug = new Bug { BugId = 2014, Content = "Test bug" };

            var repoMock = new Mock<IRepository<Bug>>();
            repoMock.Setup(repo => repo.All()).Returns((new Bug[] { bug }).AsQueryable());

            var server = new InMemoryHttpServer<Bug>(BugLoggerServicesUrl, repoMock.Object);

            // act
            var response = server.CreatePutRequest("/bugs/2014", bug);

            // assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestDeleteRequestWhenBugIdIsValidShouldDeleteBug()
        {
            // arrange
            List<Bug> bugs = new List<Bug>
            { 
                new Bug { BugId = 2014, Content = "Test bug" }
            };

            var repoMock = new Mock<IRepository<Bug>>();
            repoMock.Setup(repo => repo.All()).Returns(bugs.AsQueryable());
            repoMock.Setup(repo => repo.Delete(It.IsAny<Bug>()))
                .Callback((Bug toDelete) => bugs.Remove(toDelete));

            var server = new InMemoryHttpServer<Bug>(BugLoggerServicesUrl, repoMock.Object);

            // act
            var response = server.CreateDeleteRequest("/bugs/2014");

            // assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
            Assert.IsTrue(bugs.Count == 0);
        }
    }
}
