using MediatR;
using ControlGo.Application.Features.Comments.DTOs;

namespace ControlGo.Application.Features.Comments.Queries
{
    public class GetPostsQuery : IRequest<List<PostDto>>
    {
    }
}
