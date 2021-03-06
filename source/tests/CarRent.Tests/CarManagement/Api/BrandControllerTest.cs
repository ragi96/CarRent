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
    public class BrandControllerTests
    {
        private readonly BrandController _controller;
        private readonly IBrandService _service;

        public BrandControllerTests()
        {
            _service = A.Fake<IBrandService>();
            _controller = new BrandController(_service);
        }

        [Fact]
        public void Get_FindAll_ReturnsOkResult()
        {
            // Arrange
            var result = _controller.Get();
            // Assert
            Assert.IsType<ActionResult<ServiceResponse<List<GetBrandDto>>>>(result.Result);
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
            Assert.IsType<ActionResult<ServiceResponse<List<GetBrandDto>>>>(result.Result);
        }
    }
}