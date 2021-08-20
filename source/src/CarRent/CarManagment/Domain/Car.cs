﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagment.Application;
using CarRent.Common.Domain;

namespace CarRent.CarManagment.Domain
{
    [BsonCollection("car")]
    public class Car : Document
    {
        public string Name { get; set; }
        public GetBrandDto Brand { get; set; }
    }
}
