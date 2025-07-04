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
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Blog>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Blogs)
            .HasForeignKey(b => b.AuthorID);

        modelBuilder.Entity<BlogAuthor>().ToTable("BlogAuthor");
        modelBuilder.Entity<Blog>().ToTable("Blog");


    }

}