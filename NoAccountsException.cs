using System;
using System.Runtime.Serialization;

namespace hw_2003___Bank
{
    [Serializable]
    internal class NoAccountsException : ApplicationException
    {
        public NoAccountsException()
        {
        }

        public NoAccountsException(string message) : base(message)
        {
        }

        public NoAccountsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoAccountsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}