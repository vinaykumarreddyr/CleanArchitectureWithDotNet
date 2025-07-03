using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Mediator.Domain.Entity
{
    public class BlogAuthor
    {
        [Key]
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        //public ICollection<Blog> Blogs { get; set; } // Optional: Navigation property for one-to-many
    }
}