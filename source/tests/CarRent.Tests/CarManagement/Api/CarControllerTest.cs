using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRent.CarManagment.Application;
using CarRent.CarManagment.Domain;
using CarRent.Common.Application;
using CarRent.Controllers;
using CarRent.Tests.CarManagement.Application;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace CarRent.Tests.CarManagement.Api
{
    [TestFixture]
    public class CarControllerTest
    {
        CarController _controller;
        ICarService _service;

        [SetUp]
        public void Init()
        {
            _service = A.Fake<ICarService>();
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
        public void Get_WhenCalled_ReturnsTaskIActionResult()
        {
            // Arrange
            var task = A.Fake<Task<ServiceResponse<IEnumerable<GetCarDto>>>>();
            // Act
            var result = _controller.Get();
            A.CallTo(() => _service.FindAll()).MustHaveHappened();
            A.CallTo(() => _service.FindAll()).Equals(task);

            // Assert
            Assert.IsInstanceOf<Task<IActionResult>>(result);

        }
    }
}
