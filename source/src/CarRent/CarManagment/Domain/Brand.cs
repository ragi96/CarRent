using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Common;
using CarRent.Common.Domain;
using MongoDB.Entities;

namespace CarRent.CarManagment.Domain
{
    [Collection("Brand")]
    public class Brand : Entity
    {
        public string Name { get; set; }
    }
}
