using Mediator.Domain.Entity;
//using Mediator.Infrastructure.Context;
//namespace Mediator.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogAuthor> BlogAuthors { get; set; } // Make plural

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().ToTable("Blog").HasKey(entity=>entity.ID);
        modelBuilder.Entity<BlogAuthor>().ToTable("BlogAuthor")
            .HasKey(a => a.AuthorID); // Explicit primary key
    }
}