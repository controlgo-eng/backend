using MediatR;
using Microsoft.AspNetCore.Mvc;
using Worldsys.Application.Features.Comments.DTOs;
using Worldsys.Application.Features.Comments.Queries;

namespace Worldsys.API.Controllers
{
    /// <summary>
    /// Api Controller de Posts
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Obtiene todos los Posts de una api externa
        /// </summary>        
        /// <returns>Lista de Post (DTO)</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PostDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<PostDto>> Get()
        {
            return await this.mediator.Send(new GetPostsQuery());
        }
    }
}
