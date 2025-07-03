using Mediator.Domain.Entity;
using Mediator.Domain.Repository;
//using Mediator.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mediator.Infrastructure.Repository
{
    public class BlogAuthorRepository : IBlogAuthorRepository
    {
        private readonly BlogDbContext _dbContext;

        public BlogAuthorRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BlogAuthor> Create(BlogAuthor author)
        {
            await _dbContext.BlogAuthors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
            return author;
        }

        public async Task<int> Delete(int id)
        {
            var author = await _dbContext.BlogAuthors.FindAsync(id);
            if (author != null)
            {
                _dbContext.BlogAuthors.Remove(author);
                return await _dbContext.SaveChangesAsync(); // Return the actual result
            }
            return 0;
        }

        public async Task<List<BlogAuthor>> GetAll()
        {
            return await _dbContext.BlogAuthors.ToListAsync();
        }

        public async Task<BlogAuthor> GetById(int id)
        {
            return await _dbContext.BlogAuthors.FindAsync(id);
        }

        public async Task<int> Update(int id, BlogAuthor author)
        {
            var existingAuthor = await _dbContext.BlogAuthors.FindAsync(id);
            if (existingAuthor != null)
            {
                _dbContext.Entry(existingAuthor).CurrentValues.SetValues(author);
                return await _dbContext.SaveChangesAsync(); // Make this async
            }
            return 0;
        }
    }
}