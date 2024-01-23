using Refit;
using Worldsys.Infrastructure.Features.Posts.Contracts;

namespace Worldsys.Infrastructure.Features.Posts.Services
{
    public interface IExternalPostsService
    {
        /// <summary>
        /// Interface con uso de Refit para invocacion de Apis. Documentación y ejemplos: https://github.com/reactiveui/refit
        /// </summary>
        /// <returns></returns>
        [Get("/posts")]
        Task<List<GetPostsResponse>> GetPosts();
    }
}
