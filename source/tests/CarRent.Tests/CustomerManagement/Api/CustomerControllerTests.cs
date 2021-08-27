using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.Common.Application;
using CarRent.CustomerManagement.Api;
using CarRent.CustomerManagement.Application;
using CarRent.CustomerManagement.Application.Dto;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CarRent.Tests.CustomerManagement.Api
{
    public class CustomerControllerTests
    {
        private readonly CustomerController _controller;
        private readonly ICustomerService _service;

        public CustomerControllerTests()
        {
            _service = A.Fake<ICustomerService>();
            _controller = new CustomerController(_service);
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
            var task = A.Fake<Task<ServiceResponse<IEnumerable<GetCustomerDto>>>>();
            // Act
            var result = _controller.Get();
            A.CallTo(() => _service.FindAll()).MustHaveHappened();
            A.CallTo(() => _service.FindAll()).Equals(task);

            // Assert
            Assert.IsType<Task<IActionResult>>(result);
        }
    }
}