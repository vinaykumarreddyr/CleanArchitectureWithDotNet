using Mediator.Apllication.BlogAuthor.Query.GetAllBlogAuthors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.BlogAuthor.Query.GetBlogAuthorById
{
    public class GetBlogAuthorQuery : IRequest<BlogAuthorVM>
    {
        public int BlogAuthorId { get; set; }
        public GetBlogAuthorQuery(int id)
        {
            BlogAuthorId = id;
        }
    }
}
