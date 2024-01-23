using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worldsys.Domain.Customers.Models;
using Worldsys.Domain.Posts.Models;

namespace Worldsys.Domain.Posts.Services
{
    public interface IPostService
    {
        Task<IList<Post>> GetPosts();
    }
}
