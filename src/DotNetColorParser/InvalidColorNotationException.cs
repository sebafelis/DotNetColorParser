using System;
using System.Runtime.Serialization;

namespace DotNetColorParser
{
    public class InvalidColorNotationException : ArgumentException
    {
        public InvalidColorNotationException()
        {
        }

        public InvalidColorNotationException(string message) : base(message)
        {
        }

        public InvalidColorNotationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InvalidColorNotationException(string message, string paramName) : base(message, paramName)
        {
        }

        public InvalidColorNotationException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }

        protected InvalidColorNotationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
