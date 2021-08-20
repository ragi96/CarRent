using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRent.Common.Domain;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CarRent.Tests.Common
{
    public class BsonCollectionAttributeTests
    {
        [Fact]
        public void BsonCollection_Constructor_CollectionNameShouldBeTest()
        {
            // Arrange
            var result = new BsonCollectionAttribute("Test");
            // Assert
            Assert.Equal("Test",result.CollectionName);
        }

        [Fact]
        public void BsonCollection_Constructor_CollectionNameShouldNotBeTest()
        {
            // Arrange
            var result = new BsonCollectionAttribute("Test2");
            // Assert
            Assert.NotEqual("Test", result.CollectionName);
        }
    }
}
