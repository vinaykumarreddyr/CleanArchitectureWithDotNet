using MediatR;

namespace Mediator.Apllication.Blogs.Query.GetBlogbyID
{
    public class GetByIDQuery : IRequest<BlogVM>
    {
        public int ID { get; set; }
        public GetByIDQuery(int id)
        {
            ID = id;
        }

    }
}
