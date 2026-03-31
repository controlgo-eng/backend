using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ControlGo.Domain.Exceptions;
using FluentValidation;
using Refit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using ControlGo.Application.CommonDTO;

namespace ControlGo.Infrastructure.Bootstrap.Extensions.ApplicationBuilder
{
    public static class ExceptionHandlerBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder, bool includeErrorDetailInResponse = false)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>(includeErrorDetailInResponse);
        }
    }

    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly bool _includeErrorDetailInResponse;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger, bool includeErrorDetailInResponse)
        {
            this._logger = logger;
            this._includeErrorDetailInResponse = includeErrorDetailInResponse;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var exceptionHandlerPathFeature = httpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error is ValidationException validationException)
            {

                var validationResults = new ValidationResponseDTO();
                validationResults.Errors.AddRange(from error in validationException.Errors
                                                  select new ValidationDetailDTO(error.PropertyName, error.ErrorMessage));

                var errorObject = JsonConvert.SerializeObject(validationResults);

                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsync(errorObject, Encoding.UTF8);
            }
            else if (exceptionHandlerPathFeature?.Error is ApiException apiException)
            {
                this._logger.LogError(
                    "API Error: error en llamada a {api}: {status} {reason} \n{result}",
                    apiException.RequestMessage.RequestUri,
                    (int)apiException.StatusCode,
                    apiException.ReasonPhrase,
                    apiException.Content);

                await this.WriteGenericErrorToResponse(
                    httpContext,
                    new { Exception = apiException.ToString(), Content = apiException.Content });
            }
            else if (exceptionHandlerPathFeature?.Error is DomainException domainException)
            {
                var errorObject = JsonConvert.SerializeObject(new ErrorResponseDTO
                {
                    Errors = [new ErrorDetailDTO(
                        domainException.ErrorCode,
                        CutArgumentMessage(domainException.Message))]
                });

                httpContext.Response.StatusCode = (int)domainException.StatusCode;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsync(errorObject, Encoding.UTF8);
            }
            else if (exceptionHandlerPathFeature?.Error is ArgumentException argumentException)
            {
                _logger.LogError($"Ocurrio un error en la Aplicacion. Por favor intentá mas tarde. {0} Detalle: {argumentException.Message}");
                var errorObject = JsonConvert.SerializeObject(new ValidationResponseDTO
                {
                    Errors = [new ValidationDetailDTO(
                        argumentException.ParamName ?? "",
                        CutArgumentMessage(argumentException.Message))]
                });

                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsync(errorObject, Encoding.UTF8);
            }
            else
            {
                await this.WriteGenericErrorToResponse(
                    httpContext,
                    new Exception(
                        $"Unhandled by {nameof(ExceptionHandlerMiddleware)}",
                        exceptionHandlerPathFeature?.Error).ToString());
            }
        }

        private static string CutArgumentMessage(string msg)
        {
            return msg.Split(Environment.NewLine).FirstOrDefault() ?? "";
        }

        private async Task WriteGenericErrorToResponse(HttpContext httpContext, object errorDetail)
        {

            _logger.LogError($"Ocurrio un error en la Aplicacion. Por favor intentá mas tarde. {0} Detalle: {errorDetail}");            
            var errorObject = JsonConvert.SerializeObject(new ErrorResponseDTO
            {
                Errors = [new ErrorDetailDTO(500, CutArgumentMessage(string.Format("Ocurrio un error en la Aplicacion. Por favor intentá mas tarde. {0}", this._includeErrorDetailInResponse ? $"Detalle: {errorDetail}" : "")))]
            },
            new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            });

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(errorObject, Encoding.UTF8);
        }
    }
}
