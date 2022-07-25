
using MediatR;
using Microsoft.Extensions.Logging;

namespace Nutri.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Este Handle se ejecutara cuando algo mal suceda en el handler de los commands y los queries.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = (typeof(TRequest).Name);
                _logger.LogError(ex, "Application request: Sucedio una exception para el request {Name} {@Request}", requestName, request);
                throw;
            }
        }
    }
}
