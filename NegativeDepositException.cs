using System;
using System.Runtime.Serialization;

namespace hw_2003___Bank
{
    [Serializable]
    internal class NegativeDepositException : ApplicationException
    {
        public NegativeDepositException()
        {
        }

        public NegativeDepositException(string message) : base(message)
        {
        }

        public NegativeDepositException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NegativeDepositException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}