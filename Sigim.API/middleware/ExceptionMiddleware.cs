using Complii.Application.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sigim.Application.Models;
using System.Net;

namespace Complii.AdminAPI.middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                _logger.LogError(ex, ex.Message);
                var statusCode = (int)HttpStatusCode.InternalServerError;
                ApiResult<string?>? result = null;
                switch (ex)
                {
                    case NotFoundException notFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = new ApiResult<string?>(statusCode, "VALIDATION_ERROR", validationJson);
                        break;

                    case BadRequestException badRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    default:
                        break;
                }

                if (result == null)
                    result = new ApiResult<string?>(statusCode, ex.Message, ex.StackTrace);


                context.Response.StatusCode = statusCode;
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                };
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result, settings));

            }

        }

    }
}
