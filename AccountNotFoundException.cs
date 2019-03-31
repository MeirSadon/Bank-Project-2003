using System;
using System.Runtime.Serialization;

namespace hw_2003___Bank
{
    [Serializable]
    internal class AccountNotFoundException : ApplicationException
    {
        public AccountNotFoundException()
        {
        }

        public AccountNotFoundException(string message) : base(message)
        {
        }

        public AccountNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}