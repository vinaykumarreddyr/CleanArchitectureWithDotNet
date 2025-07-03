using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.BlogAuthors.Command.DeleteBlogAuthor
{
    public class DeleteBlogAuthorCommand:IRequest<int>
    {
        public int AuthorID { get; set; }

        // Add this constructor
        public DeleteBlogAuthorCommand(int id)
        {
            AuthorID = id;
        }
    }
}
