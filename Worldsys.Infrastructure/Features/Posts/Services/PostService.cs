using Worldsys.Domain.Posts.Models;
using Worldsys.Domain.Posts.Services;
using Worldsys.Infrastructure.Cache;
using Worldsys.Infrastructure.Features.Posts.Contracts;

namespace Worldsys.Infrastructure.Features.Posts.Services
{
    public class PostService : IPostService
    {
        private readonly IExternalPostsService _externalPostsService;
        private readonly CacheService _cacheService;
        public PostService(IExternalPostsService externalPostsService, CacheService cacheService)
        {
            this._externalPostsService = externalPostsService;
            this._cacheService = cacheService;            
        }

        public async Task<IList<Post>> GetPosts()
        {

            var response = new List<GetPostsResponse>();
            var dataRedis = await _cacheService.GetAsync<List<GetPostsResponse>>("Post");
            if (dataRedis == null)
            {
                response = await this._externalPostsService.GetPosts();
                await _cacheService.SetAsync("Post", response, "00:05:00");
            }
            else
            {
                response = dataRedis;
            }
            //This method is an example calling a 3rd party API using Refit
            
            return response.Select(x => new Post { Id = x.Id, Body = x.Body, Title = x.Title, UserId = x.UserId }).ToList();
        }

    }
}
