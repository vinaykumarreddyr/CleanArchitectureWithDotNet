using Mediator.Apllication.BlogAuthor.Query.GetAllBlogAuthors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.BlogAuthor.Command.CreateBlogAuthor
{
    public class CreateBlogAuthorCommand : IRequest<BlogAuthorVM>
    {
        public string Name { get; set; }
        public bool Isactive { get; set; }
    }
}
