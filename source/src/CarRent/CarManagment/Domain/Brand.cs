using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Common;
using CarRent.Common.Domain;

namespace CarRent.CarManagment.Domain
{
    [BsonCollection("brand")]
    public class Brand : Document
    {
        public string Name { get; set; }
    }
}
