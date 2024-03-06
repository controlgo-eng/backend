using MediatR;
using Microsoft.AspNetCore.Mvc;
using Worldsys.Application.CommonDTO;
using Worldsys.Application.Features.Customers.Command;
using Worldsys.Application.Features.Customers.DTOs;
using Worldsys.Application.Features.Customers.Queries;


namespace Worldsys.API.Controllers.Customers
{
    /// <summary>
    /// Api Controller  de Clientes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Obtiene un cliente por ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Cliente (DTO)</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponseDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponseDTO))]
        public async Task<CustomerDto> Get(int id)
        {
            return await this._mediator.Send(new GetCustomerByIdQuery(id));
        }

        /// <summary>
        /// Creación de un cliente
        /// </summary>
        /// <param name="request">Comando de creación de cliente, con los atributos del mismo</param>
        /// <returns>Cliente creado (DTO)</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationResponseDTO))]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand request)
        {
            var result = await this._mediator.Send(request);
            //This should return created for the new resource
            return this.CreatedAtAction(nameof(this.Get), new { id = result.Id }, result);
        }

        /// <summary>
        /// Actualiza un cliente. Lo crea con el ID provisto si no existe.
        /// </summary>
        /// <param name="request">Comando de actualización de cliente, con los atributos del mismo</param>
        /// <returns>true en caso de actualizar OK</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand request)
        {
            var result = await this._mediator.Send(request);
            return this.Ok(result);
        }

        /// <summary>
        /// Elimina un cliente mediante su ID
        /// </summary>
        /// <param name="id">Comando de eliminación de cliente. Como único atributo debería indicar el 'Id'</param>
        /// <returns>No retorna contenido por eso siempre es un 204</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task DeleteCustomer(int id)
        {
            await this._mediator.Send(new DeleteCustomerCommand { Id = id });
        }

        /// <summary>
        /// Elimina un cliente mediante su ID
        /// </summary>
        /// <param name="id">Comando de obtencion de clientes filtrados por status</param>
        /// <returns>Listado de clientes (DTO)</returns>
        [HttpGet("GetCustomersByStatus/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCustomersByStatus(int status)
        {
            return Ok(await this._mediator.Send(new GetCustomersByStatusQuery(status)));
        }
    }
}
