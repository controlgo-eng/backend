using System;
using System.Net;

namespace Worldsys.Domain.Exceptions
{
    [Serializable]
    public class CustomerDomainException : DomainException
    {
        public CustomerDomainException() { }

        public CustomerDomainException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest, int errorCode = 0 ) : base(message, statusCode, errorCode) { }

        public CustomerDomainException(string message, Exception exception, HttpStatusCode statusCode = HttpStatusCode.BadRequest, int errorCode = 0) : base(message, exception, statusCode, errorCode) { }
    }
}
