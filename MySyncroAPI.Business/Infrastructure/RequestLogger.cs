using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MySyncroAPI.Business.Infrastructure
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILoggerFactory _loggerFactory;

        public RequestLogger(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var logger = _loggerFactory.CreateLogger<TRequest>();

            // Do some logging to record the Request
            logger.LogInformation(request.ToString());

            return Task.CompletedTask;
        }

    }
}
