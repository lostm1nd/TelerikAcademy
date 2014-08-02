namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using System.Linq;
    using Telerik.JustMock;

    public class JustMockCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            this.CarsData = Mock.Create<ICarsRepository>();

            Mock.Arrange(() => this.CarsData.Add(Arg.IsAny<Car>())).DoNothing();

            Mock.Arrange(() => this.CarsData.All()).Returns(this.FakeCarCollection);

            Mock.Arrange(() => this.CarsData.Search(Arg.AnyString))
                .Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());

            Mock.Arrange(() => this.CarsData.GetById(Arg.AnyInt))
                .Returns(this.FakeCarCollection.First());

            // HW starts here
            Mock.Arrange(() => this.CarsData.Search(Arg.NullOrEmpty))
                .Returns(this.FakeCarCollection.ToList());

            Mock.Arrange(() => this.CarsData.GetById(Arg.Is<int>(101)))
                .Returns<Car>(null);

            Mock.Arrange(() => this.CarsData.SortedByMake())
                .Returns(this.FakeCarCollection.OrderBy(c => c.Make).ToList());

            Mock.Arrange(() => this.CarsData.SortedByYear())
                .Returns(this.FakeCarCollection.OrderBy(c => c.Year).ToList());

            Mock.Arrange(() => this.CarsData.Remove(Arg.IsAny<Car>()))
                .DoInstead(() => this.FakeCarCollection.ToList().RemoveAt(0));

            Mock.Arrange(() => this.CarsData.TotalCars)
                .Returns(this.FakeCarCollection.ToList().Count);
        }
    }
}
