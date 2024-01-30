using MediatR;
using Microsoft.AspNetCore.Mvc;
using Worldsys.Application.Features.Comments.DTOs;
using Worldsys.Application.Features.Comments.Queries;
using Worldsys.Application.Features.Customers.Command;
using Worldsys.Application.Features.RabbitMQ.Command;

namespace Worldsys.API.Controllers
{
    /// <summary>
    /// Api Controller  de RabbitMq
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMqController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RabbitMqController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Obtiene todos los Posts de una api externa
        /// </summary>        
        /// <returns>Lista de Post (DTO)</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageCommand request)
        {
            var result = await this._mediator.Send(request);
            return Ok(result);
        }
    }
}
