using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.BlogAuthors.Command.UpdateBlogAuthor
{
    public class UpdateBlogAuthorCommand : IRequest<int>
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public bool Isactive { get; set; }
    }
}
