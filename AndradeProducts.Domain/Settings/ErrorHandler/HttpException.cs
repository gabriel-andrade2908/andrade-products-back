using System;
using System.Collections.Generic;
using System.Net;

namespace AndradeProducts.Domain.Settings.ErrorHandler
{
    public abstract class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; protected set; }
        public IList<string> Errors { get; protected set; }

        protected HttpException(string message, HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
            Errors = new string[] { message };
        }

        protected HttpException(IList<string> messages, HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
            Errors = messages;
        }
    }
}
