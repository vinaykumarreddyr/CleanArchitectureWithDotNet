using Mediator.Apllication.Blogs.Query.GetBlogbyID;
using MediatR;

namespace Mediator.Apllication.Blogs.Command.CreateBlog
{
    public class CreateBlogCommand : IRequest<BlogVM>
    {
        //public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
