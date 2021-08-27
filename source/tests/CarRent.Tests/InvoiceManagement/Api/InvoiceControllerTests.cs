using System.Collections.Generic;
using System.Threading.Tasks;
using CarRent.Common.Application;
using CarRent.CustomerManagement.Application.Dto;
using CarRent.InvoiceManagement.Api;
using CarRent.InvoiceManagement.Application;
using CarRent.InvoiceManagement.Application.Dto;
using CarRent.ReservationManagement.Api;
using CarRent.ReservationManagement.Application;
using CarRent.ReservationManagement.Application.Dto;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CarRent.Tests.InvoiceManagement.Api
{
    public class InvoiceControllerTests
    {
        private readonly InvoiceController _controller;
        private readonly IInvoiceService _service;

        public InvoiceControllerTests()
        {
            _service = A.Fake<IInvoiceService>();
            _controller = new InvoiceController(_service);
        }

        [Fact]
        public void Get_FindAll_ReturnsOkResult()
        {
            // Arrange
            var result = _controller.Get();
            // Assert
            Assert.IsType<ActionResult<ServiceResponse<List<GetInvoiceDto>>>>(result.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsTaskIActionResult()
        {
            // Arrange
            var task = A.Fake<Task<ServiceResponse<IEnumerable<GetInvoiceDto>>>>();
            // Act
            var result = _controller.Get();
            A.CallTo(() => _service.FindAll()).MustHaveHappened();
            A.CallTo(() => _service.FindAll()).Equals(task);

            // Assert
            Assert.IsType<ActionResult<ServiceResponse<List<GetInvoiceDto>>>>(result.Result);
        }
    }
}