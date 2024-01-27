using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worldsys.Application.Features.Customers.Command;
using Worldsys.Application.Features.Customers.DTOs;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.QuequeMessage.Services;

namespace Worldsys.Application.Features.RabbitMQ.Command
{
    internal class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, bool>
    {

        private readonly IMessageQueueService _messageQueueService;

        public SendMessageCommandHandler(IMessageQueueService messageQueueService)
        {
            _messageQueueService = messageQueueService;
        }

        public Task<bool> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            //Envio un mensaje nuevo a la cola de RabbitMQ
            this._messageQueueService.EnqueueMessageAsync(request.QuequeName, request);
            return Task.FromResult(true);
        }
    }
}
