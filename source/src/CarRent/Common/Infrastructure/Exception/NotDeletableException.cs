using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CarRent.Common.Infrastructure
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class NotDeletableException : Exception
    {
        public NotDeletableException()
        {
        }

        public NotDeletableException(string message)
            : base(message)
        {
        }

        public NotDeletableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected NotDeletableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override string Message { get; } = "Not Deletable";
    }
}