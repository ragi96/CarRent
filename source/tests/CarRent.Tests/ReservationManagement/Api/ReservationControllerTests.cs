using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.Common.Application;
using CarRent.CustomerManagement.Application.Dto;
using CarRent.ReservationManagement.Api;
using CarRent.ReservationManagement.Application;
using CarRent.ReservationManagement.Application.Dto;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CarRent.Tests.ReservationManagement.Api
{
    public class ReservationControllerTests
    {
        private readonly ReservationController _controller;
        private readonly IReservationService _service;

        public ReservationControllerTests()
        {
            _service = A.Fake<IReservationService>();
            _controller = new ReservationController(_service);
        }

        [Fact]
        public void Get_FindAll_ReturnsOkResult()
        {
            // Arrange
            var result = _controller.Get();
            // Assert
            Assert.IsType<ActionResult<ServiceResponse<List<GetReservationDto>>>>(result.Result);
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
            Assert.IsType<ActionResult<ServiceResponse<List<GetReservationDto>>>>(result.Result);
        }
    }
}