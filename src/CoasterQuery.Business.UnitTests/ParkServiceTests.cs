using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoasterQuery.Data.Models;
using CoasterQuery.Data.Repositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CoasterQuery.Business.Unit.Tests
{
    [TestClass]
    public class ParkServiceTests
    {
        private Mock<IRepository<Park>> _parkRepositoryMock;

        private IEnumerable<Park> DummyParks => new List<Park>
        {
            new Park
            {
                Address = "123 fake address",
                City = "Fake City",
                Country = "USA",
                IsApproved = true,
                IsDefunct = false,
                Name = "Paul's Park",
                Notes = "Notes notes notes",
                ParkID = 1,
                State = "MN",
                Website = "http://google.com",
                Zip = "12345"
            }
        };

        [TestInitialize]
        public void TesSetup()
        {
            _parkRepositoryMock = new Mock<IRepository<Park>>();
            _parkRepositoryMock.Setup(m => m.GetAll()).Returns(Task.FromResult(DummyParks));
        }

        [TestMethod]
        public async Task ParkService_GetAllParks_ReturnsFullList()
        {
            var underTest = new ParkService(_parkRepositoryMock.Object);
            underTest.Should().NotBeNull("because we expect an instance to be created.");

            var result = await underTest.GetAllParks() as IList<Park>;

            result.Should().NotBeNull("because we expect a result.");
            result.Should().HaveCount(DummyParks.Count(), "because the returned count should match DummyParks count.");
        }
    }
}