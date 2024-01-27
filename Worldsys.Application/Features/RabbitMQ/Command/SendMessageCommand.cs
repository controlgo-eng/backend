using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worldsys.Application.Features.Customers.DTOs;

namespace Worldsys.Application.Features.RabbitMQ.Command
{
    public class SendMessageCommand : IRequest<bool>
    {
        public string QuequeName { get; set; } = "";
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
    }
}
