using MediatR;
using Worldsys.Application.Features.Comments.DTOs;

namespace Worldsys.Application.Features.Comments.Queries
{
    public class GetPostsQuery : IRequest<List<PostDto>>
    {
    }
}
