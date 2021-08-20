using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagment.Application;
using CarRent.Common;
using CarRent.Common.Domain;
using MongoDB.Bson;

namespace CarRent.CarManagment.Domain
{
    [BsonCollection("car")]
    public class Car : Document
    {
        public string Name { get; set; }
        public GetBrandDto Brand { get; set; }

    }
}
