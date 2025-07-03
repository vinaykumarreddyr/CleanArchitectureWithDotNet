using Mediator.Apllication.Common.Mappings;
using Mediator.Domain.Entity;

namespace Mediator.Apllication.Blogs.Query.GetBlogbyID
{
    public class BlogVM:IMapFrom<Blog>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
