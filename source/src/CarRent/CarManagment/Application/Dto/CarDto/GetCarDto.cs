﻿using System.ComponentModel.DataAnnotations;

namespace CarRent.CarManagment.Application
{
    public class GetCarDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public GetBrandDto BrandDto { get; set; }
    }
}