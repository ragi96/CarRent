﻿using System;
using System.Runtime.Serialization;

namespace CarRent.Common.Infrastructure
{
    [Serializable]
    public class NotDeletableException : Exception
    {
        public override string Message { get; } = "Not Deletable";

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
    }
}
