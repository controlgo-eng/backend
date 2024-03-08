using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Worldsys.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;        
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            this._logger = logger;            
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Executing command {CommandName} with request {@Command}", request.GetType().FullName, JsonConvert.SerializeObject(request));
            TResponse? response = default;
            try
            {
                response = await next();
            }
            finally
            {                
                this._logger.LogInformation("Executed command {CommandName} with response {@Response}", request.GetType().FullName, response != null ? JsonConvert.SerializeObject(response) : null);
            }

            return response;
        }
    }
}
