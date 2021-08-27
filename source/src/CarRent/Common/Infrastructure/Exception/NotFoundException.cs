using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CarRent.Common.Infrastructure
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class NotFoundException : Exception
    {
        public override string Message { get; } = "Not Found";

        public NotFoundException()
        {
        }
        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
