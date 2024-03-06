using System;
using System.Net;

namespace Worldsys.Domain.Exceptions
{

    [Serializable]
    public class DomainException : Exception
    {
        public DomainException() { }
        public DomainException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest, int errorCode = 0) : base(message) { StatusCode = statusCode; ErrorCode = errorCode; }
        public DomainException(string message, Exception inner, HttpStatusCode statusCode = HttpStatusCode.BadRequest, int errorCode = 0) : base(message, inner) { StatusCode = statusCode; ErrorCode = errorCode; }

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;
        public int ErrorCode { get; set; } = 0;
    }
}
