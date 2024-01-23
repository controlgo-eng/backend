using Worldsys.Domain.Posts.Models;
using Worldsys.Domain.Posts.Services;

namespace Worldsys.Infrastructure.Features.Posts.Services
{
    public class PostService : IPostService
    {
        private readonly IExternalPostsService externalPostsService;
        public PostService(IExternalPostsService externalPostsService)
        {
            this.externalPostsService = externalPostsService;
        }

        public async Task<IList<Post>> GetPosts()
        {
            //This method is an example calling a 3rd party API using Refit
            var response = await this.externalPostsService.GetPosts();
            return response.Select(x => new Post { Id = x.Id, Body = x.Body, Title = x.Title, UserId = x.UserId }).ToList();
        }

    }
}
