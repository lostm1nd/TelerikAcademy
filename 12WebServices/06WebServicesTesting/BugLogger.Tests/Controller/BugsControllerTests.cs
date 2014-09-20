namespace BugLogger.Tests.Controller
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Hosting;
    using System.Web.Http.Routing;

    using Moq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using BugLogger.Services;
    using BugLogger.Models;
    using BugLogger.Data;
    using BugLogger.Services.Controllers;
    using System.Collections.Generic;

    [TestClass]
    public class BugsControllerTests
    {
        [TestMethod]
        public void GetAllShouldReturnAllEntities()
        {
            // arrange
            Bug[] bugs =
            {
                new Bug() { Content = "Bug1" },
                new Bug() { Content = "Bug2" }
            };

            var repoMock = new Mock<IRepository<Bug>>();
            repoMock.Setup(x => x.All()).Returns(bugs.AsQueryable());

            var bugsControllers = new BugsController(repoMock.Object);

            // act
            var result = bugsControllers.GetAllBugs().ToArray<Bug>();

            // assert
            CollectionAssert.AreEqual(bugs, result);
        }

        [TestMethod]
        public void PostBugShouldCallRepoAddAndSaveChanges()
        {
            // arrange
            List<Bug> bugsInRepoMock = new List<Bug>();
            Bug bug = new Bug() { Content = "Bug1" };

            var repoMock = new Mock<IRepository<Bug>>();
            repoMock.Setup(x => x.Add(It.IsAny<Bug>()))
                .Callback((Bug b) => bugsInRepoMock.Add(b));

            repoMock.Setup(x => x.SaveChanges()).Returns(1);

            var bugsController = new BugsController(repoMock.Object);
            this.SetupController(bugsController);

            // act
            bugsController.PostBug(bug);

            // assert
            repoMock.Verify(x => x.SaveChanges(), Times.Exactly(1));
            Assert.AreEqual(1, bugsInRepoMock.Count);
            Assert.AreEqual("Bug1", bugsInRepoMock[0].Content);
            Assert.IsNotNull(bugsInRepoMock[0].LogDate);
            Assert.IsNotNull(bugsInRepoMock[0].Status);
        }

        // You need the Microsoft.AspNet.WebApi.Core package!!!!
        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://localhost:21878/api/Bugs";

            //Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };

            controller.Request = request;

            //Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            //Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "bugs" }
                    });
        }
    }
}
