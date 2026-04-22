using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlGo.Domain.Customers;
using ControlGo.Domain.Posts.Models;

namespace ControlGo.Domain.Posts.Services
{
    public interface IPostService
    {
        Task<IList<Post>> GetPosts();
    }
}
