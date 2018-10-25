using System;

namespace HD.Exceptions
{
    public class InvalidStateOperationException : Exception
    {
        public InvalidStateOperationException(string message) : base(message)
        {
        }
    }
}
