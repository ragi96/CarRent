using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Common.Infrastructure
{
    public class NotFoundException : Exception
    {
        public override string Message { get; } = "Not Found";
    }
}
