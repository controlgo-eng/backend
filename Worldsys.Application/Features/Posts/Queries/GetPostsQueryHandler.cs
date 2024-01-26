using AutoMapper;
using MediatR;
using Worldsys.Application.Features.Comments.DTOs;
using Worldsys.Domain.Posts.Services;

namespace Worldsys.Application.Features.Comments.Queries
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<PostDto>>
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public GetPostsQueryHandler(IPostService postService, IMapper mapper)
        {
            this._postService = postService;
            this._mapper = mapper;
        }

        public async Task<List<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            return this._mapper.Map<List<PostDto>>(await this._postService.GetPosts());                                    
        }     
    }
}
