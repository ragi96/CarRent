using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.CarManagement.Api;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Application.Dto.CarDto;
using CarRent.Common.Application;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CarRent.Tests.CarManagement.Api
{
    public class CarControllerTests
    {
        private readonly CarController _controller;
        private readonly ICarService _service;

        public CarControllerTests()
        {
            _service = A.Fake<ICarService>();
            _controller = new CarController(_service);
        }

        [Fact]
        public void Get_FindAll_ReturnsOkResult()
        {
            // Arrange
            var result = _controller.Get();
            // Assert
            Assert.IsType<ActionResult<ServiceResponse<List<GetCarDto>>>>(result.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsTaskIActionResult()
        {
            // Arrange
            var task = A.Fake<Task<ServiceResponse<IEnumerable<GetCarDto>>>>();
            // Act
            var result = _controller.Get();
            A.CallTo(() => _service.FindAll()).MustHaveHappened();
            A.CallTo(() => _service.FindAll()).Equals(task);

            // Assert
            Assert.IsType<ActionResult<ServiceResponse<List<GetCarDto>>>>(result.Result);
        }
    }
}