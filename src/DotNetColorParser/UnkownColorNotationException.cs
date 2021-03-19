using System;
using System.Runtime.Serialization;

namespace DotNetColorParser
{
    public class UnkownColorNotationException : ArgumentException
    {
        public UnkownColorNotationException()
        {
        }

        public UnkownColorNotationException(string message) : base(message)
        {
        }

        public UnkownColorNotationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public UnkownColorNotationException(string message, string paramName) : base(message, paramName)
        {
        }

        public UnkownColorNotationException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }

        protected UnkownColorNotationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
