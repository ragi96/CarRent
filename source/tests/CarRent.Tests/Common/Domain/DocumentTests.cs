using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRent.Common.Domain;
using MongoDB.Bson;
using Xunit;

namespace CarRent.Tests.Common
{
    public class DocumentTests
    {

        [Fact]
        public void Document_Create_ObjectIdCheckTimestamp()
        {
            // Arrange
            var timestamp = 1629490844;
            var objectId = new ObjectId(timestamp, 12, 12, 5 );
            // act
            var document = new Document() { Id = objectId};

            Assert.Equal(timestamp, document.Id.Timestamp);
        }

        [Fact]
        public void Document_Create_IdCreationTimeShouldBeCreatedAt()
        {
            // Arrange
            var timestamp = 1629490844;
            var objectId = new ObjectId(timestamp, 12, 12, 5);
            // act
            var document = new Document() { Id = objectId };

            Assert.Equal(document.CreatedAt, document.Id.CreationTime);
        }
    }
}
