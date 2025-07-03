using Mediator.Apllication.Blogs.Query.GetBlogbyID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.Blogs.Query.GetallBlogs
{
    public class GetBlogQuery : IRequest<List<BlogVM>>
    {
    }
}
