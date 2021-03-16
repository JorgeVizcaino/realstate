using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using RealState.Application.Common.Interfaces;

namespace RealState.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ILogger _logger;

        public RequestLogger(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            _logger.LogInformation("Northwind Request: {Name} {@UserId} {@Request}",
                name, _currentUserService.UserId, request);

            return Task.CompletedTask;
        }
    }
}