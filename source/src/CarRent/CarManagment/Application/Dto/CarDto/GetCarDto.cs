using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagment.Domain;
using CarRent.Common;

namespace CarRent.CarManagment.Application
{
    public class GetCarDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public GetBrandDto BrandDto { get; set; }
    }
}
