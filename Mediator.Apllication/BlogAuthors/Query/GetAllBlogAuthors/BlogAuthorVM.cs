using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.BlogAuthor.Query.GetAllBlogAuthors
{
    public class BlogAuthorVM
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public bool Isactive { get; set; }
    }
}
