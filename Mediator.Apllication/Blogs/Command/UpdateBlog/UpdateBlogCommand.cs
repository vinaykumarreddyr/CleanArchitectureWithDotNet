using Mediator.Apllication.Blogs.Query.GetBlogbyID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.Blogs.Command.DeleteBlog
{
    public class UpdateBlogCommand : IRequest<int>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
