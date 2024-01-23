﻿using System.Collections.Generic;
using System.Net;

namespace AndradeProducts.Domain.Settings.ErrorHandler.ErrorStatusCodes
{
    public class NotFoundException : HttpException
    {
        private static readonly HttpStatusCode _statusCode = HttpStatusCode.NotFound;

        public NotFoundException(string message) : base(message, _statusCode)
        {
        }

        public NotFoundException(IList<string> messages) : base(messages, _statusCode)
        {
        }
    }
}
