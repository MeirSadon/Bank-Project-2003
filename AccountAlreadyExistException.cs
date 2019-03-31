using System;
using System.Runtime.Serialization;

namespace hw_2003___Bank
{
    [Serializable]
    internal class AccountAlreadyExistException : ApplicationException
    {
        public AccountAlreadyExistException()
        {
        }

        public AccountAlreadyExistException(string message) : base(message)
        {
        }

        public AccountAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}