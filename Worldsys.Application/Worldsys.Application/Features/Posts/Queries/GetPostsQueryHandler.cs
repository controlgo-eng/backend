using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worldsys.Application.Features.Comments.DTOs;
using Worldsys.Application.Features.Customers.DTOs;
using Worldsys.Application.Features.Customers.Queries;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.Exceptions;
using Worldsys.Domain.Posts.Services;
using Worldsys.Domain.Repository;

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
            return _mapper.Map<List<PostDto>>(await this._postService.GetPosts());                                    
        }     
    }
}
