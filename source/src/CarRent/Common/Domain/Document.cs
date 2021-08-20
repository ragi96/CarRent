using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace CarRent.Common.Domain
{
    public class Document : IDocument
    {
        public ObjectId Id { get; set; } = new ObjectId();

        public DateTime CreatedAt => Id.CreationTime;
    }
}
