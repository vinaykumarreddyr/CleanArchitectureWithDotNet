namespace Mediator.Domain.Entity
{
    public class Blog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorID { get; set; } // ✅ Explicit 
        public BlogAuthor Author { get; set; }
    }
}