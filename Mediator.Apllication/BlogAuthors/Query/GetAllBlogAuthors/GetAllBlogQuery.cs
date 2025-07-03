using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.BlogAuthor.Query.GetAllBlogAuthors
{
    public class GetAllBlogQuery : IRequest<List<BlogAuthorVM>>
    {

    }
}
