using Newtonsoft.Json;
using Nutri.Application.Exceptions;
using NutriAPI.Errors;
using System.Net;

namespace NutriAPI.Middleware
{
    public class ExceptionMiddleware
    {
        //Representa al pipeline que se ejecuta en caso de q no ocurra alguna excepsion.
        private readonly RequestDelegate _next;
        //Mensaje de error 
        private readonly ILogger<ExceptionMiddleware> _logger;
        //Para saber si el programa esta en produccion o desarrollo.
        private readonly IHostEnvironment _environment;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                //Tipo de respuesta en formato json
                context.Response.ContentType = "application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;
                switch (ex)
                {
                    case NotFoundException notFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, validationJson));
                        break;
                    case BadRequestException badRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    default:
                        break;
                }
                if (string.IsNullOrEmpty(result))
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, ex.StackTrace));
                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(result);

            }
        }
    }
}
