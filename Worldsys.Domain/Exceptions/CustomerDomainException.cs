using System;

namespace Worldsys.Domain.Exceptions
{
    [Serializable]
    public class CustomerDomainException : DomainException
    {
        public CustomerDomainException() { }

        public CustomerDomainException(string message) : base(message) { }

        public CustomerDomainException(string message, Exception exception) : base(message, exception) { }

        protected CustomerDomainException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}
