using System;
using System.Runtime.Serialization;

namespace StringSum
{
    public class NegativeException : Exception
    {
        public NegativeException()
        {
        }

        public NegativeException(string message) : base(message)
        {
        }

        public NegativeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NegativeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}