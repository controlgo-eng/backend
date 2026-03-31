using ControlGo.Application.Mappers;
using ControlGo.Domain.Posts.Models;

namespace ControlGo.Application.Features.Comments.DTOs
{
    public class PostDto : ICreateMapper<Post>
    {
        public int Id { get; set; }        
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
