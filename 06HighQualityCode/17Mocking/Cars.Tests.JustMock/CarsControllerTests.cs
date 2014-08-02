namespace Cars.Tests.JustMock
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using System.Collections.Generic;
    using Cars.Models;

    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        // HW starts here
        [TestMethod]
        public void DetailsWithAValidIdShouldReturnViewWithTheCar()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(3));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DetailsShouldThrowAnExceptionWhenNullReturnsFromGetById()
        {
            this.controller.Details(101);
        }

        [TestMethod]
        public void SearchWithAValidConditionShouldReturnTwoResults()
        {
            var results = (ICollection<Car>)this.GetModel(() => this.controller.Search("validString"));

            Assert.AreEqual(2, results.ElementAt(0).Id);
            Assert.AreEqual("BMW", results.ElementAt(0).Make);
            Assert.AreEqual("330d", results.ElementAt(1).Model);
            Assert.AreEqual(2007, results.ElementAt(1).Year);
        }

        [TestMethod]
        public void SearchWithEmptyStringShouldReturnAllResults()
        {
            var results = (ICollection<Car>)this.GetModel(() => this.controller.Search(""));

            Assert.AreEqual(1, results.ElementAt(0).Id);
            Assert.AreEqual("325i", results.ElementAt(1).Model);
            Assert.AreEqual("BMW", results.ElementAt(2).Make);
            Assert.AreEqual(2010, results.ElementAt(3).Year);
        }

        [TestMethod]
        public void SearchWithNullShouldReturnAllResults()
        {
            var results = (ICollection<Car>)this.GetModel(() => this.controller.Search(null));

            Assert.AreEqual(1, results.ElementAt(0).Id);
            Assert.AreEqual("325i", results.ElementAt(1).Model);
            Assert.AreEqual("BMW", results.ElementAt(2).Make);
            Assert.AreEqual(2010, results.ElementAt(3).Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingByIdShouldThrowAnException()
        {
            this.controller.Sort("id");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingByModelShouldThrowAnException()
        {
            this.controller.Sort("model");
        }

        [TestMethod]
        public void SortingByYearShouldReturnTheFullDataSortedByYear()
        {
            var results = (ICollection<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(2005, results.ElementAt(0).Year);
            Assert.AreEqual(2007, results.ElementAt(1).Year);
            Assert.AreEqual(2008, results.ElementAt(2).Year);
            Assert.AreEqual(2010, results.ElementAt(3).Year);
        }

        [TestMethod]
        public void SortingByMakeShouldReturnTheFullDataSortedByMake()
        {
            var results = (ICollection<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual("Audi", results.ElementAt(0).Make);
            Assert.AreEqual("BMW", results.ElementAt(1).Make);
            Assert.AreEqual("BMW", results.ElementAt(2).Make);
            Assert.AreEqual("Opel", results.ElementAt(3).Make);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
