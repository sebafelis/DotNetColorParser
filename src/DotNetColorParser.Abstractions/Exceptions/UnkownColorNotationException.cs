﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DotNetColorParser.Exceptions
{
    /// <summary>
    /// Color notation is not recognize.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class UnkownColorNotationException : ArgumentException
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public UnkownColorNotationException()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public UnkownColorNotationException(string message) : base(message)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public UnkownColorNotationException(string message, Exception innerException) : base(message, innerException)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public UnkownColorNotationException(string message, string paramName) : base(message, paramName)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public UnkownColorNotationException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected UnkownColorNotationException(SerializationInfo info, StreamingContext context) : base(info, context)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }
    }
}
