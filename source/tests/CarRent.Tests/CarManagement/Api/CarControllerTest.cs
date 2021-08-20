using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRent.CarManagment.Application;
using CarRent.Common.Application;
using CarRent.Controllers;
using CarRent.Tests.CarManagement.Application;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace CarRent.Tests.CarManagement.Api
{
    public class CarControllerTest
    {
        CarController _controller;
        ICarService _service;

        public CarControllerTest()
        {
            _service = new CarServiceFake();
            _controller = new CarController(_service);
        }


        [Test]
        public void Get_FindAll_ReturnsOkResult()
        {
            // Arrange
            var result = _controller.Get();
            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Arrange
            var okResult = _controller.Get().Result as OkObjectResult;
            // Act
            var items = (ServiceResponse<IEnumerable<GetCarDto>>) okResult.Value;
            // Assert
            Assert.AreEqual(7, items.Data.Count());
        }
    }
}
