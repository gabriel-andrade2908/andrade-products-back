using AndradeProducts.Domain.Settings.ErrorHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace AndradeProducts.API.Tools.ExceptionHandler
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionHandlerController : ControllerBase
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly ILogger<ExceptionHandlerController> _logger;
        public ExceptionHandlerController(IHostEnvironment hostEnvironment, ILogger<ExceptionHandlerController> logger)
        {
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }

        [Route("error")]
        public ErrorResponse HandleException()
        {
            IExceptionHandlerFeature context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            Exception exception = context.Error;

            if (exception is HttpException httpException)
            {
                Response.StatusCode = (int)httpException.StatusCode;

                return new ErrorResponse(httpException.Errors);
            }

            if (!_hostEnvironment.IsDevelopment())
            {
                Response.StatusCode = 500;
                _logger.LogError("Exception", $"Exception: {exception.Message}, InnerException {exception.InnerException}");
                return new ErrorResponse("Não foi possível finalizar o processo. Por favor, entre em contato com o suporte.");
            }

            return new ErrorResponse(exception.Message);
        }
    }
}
