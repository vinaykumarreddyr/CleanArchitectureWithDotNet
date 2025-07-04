using MediatR;

namespace Mediator.Apllication.BlogAuthor.CreateBlogAuthorr
{
    public class CreateBlogWithAuthorCommand : IRequest<int>
    {
        public string  AuthorName { get; set; }
        public string  BlogName { get; set; }
        public string  Description { get; set; }
        public bool Isactive { get; set; }

    }
}
