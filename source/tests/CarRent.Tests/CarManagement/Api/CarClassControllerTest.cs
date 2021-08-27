using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.CarManagement.Api;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Application.Dto.BrandDto;
using CarRent.Common.Application;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CarRent.Tests.CarManagement.Api
{
    public class CarClassControllerTests
    {
        private readonly CarClassController _controller;
        private readonly ICarClassService _service;
        public CarClassControllerTests()
        {
            _service = A.Fake<ICarClassService>();
            _controller = new CarClassController(_service);
        }

        [Fact]
        public void Get_FindAll_ReturnsOkResult()
        {
            // Arrange
            var result = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsTaskIActionResult()
        {
            // Arrange
            var task = A.Fake<Task<ServiceResponse<IEnumerable<GetBrandDto>>>>();
            // Act
            var result = _controller.Get();
            A.CallTo(() => _service.FindAll()).MustHaveHappened();
            A.CallTo(() => _service.FindAll()).Equals(task);

            // Assert
            Assert.IsType<Task<IActionResult>>(result);

        }
    }
}
