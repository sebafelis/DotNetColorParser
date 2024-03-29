﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DotNetColorParser.Exceptions
{
    /// <summary>
    /// Specify color can not be parse correctly.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class InvalidColorNotationException : ArgumentException
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public InvalidColorNotationException()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public InvalidColorNotationException(string message) : base(message)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public InvalidColorNotationException(string message, Exception innerException) : base(message, innerException)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public InvalidColorNotationException(string message, string paramName) : base(message, paramName)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public InvalidColorNotationException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected InvalidColorNotationException(SerializationInfo info, StreamingContext context) : base(info, context)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }
    }
}
