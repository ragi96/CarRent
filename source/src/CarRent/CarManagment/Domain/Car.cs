using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagment.Application;
using CarRent.Common;
using CarRent.Common.Domain;
using MongoDB.Bson;
using MongoDB.Entities;

namespace CarRent.CarManagment.Domain
{
    [Collection("Car")]
    public class Car : Entity
    {
        public string Name { get; set; }
        public One<Brand> Brand { get; set; }

    }
}
