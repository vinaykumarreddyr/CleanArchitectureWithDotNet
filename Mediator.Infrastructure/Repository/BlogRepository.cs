using Mediator.Domain.Entity;
using Mediator.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Infrastructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _dbContext;
        public BlogRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Blog> Createasync(Blog blog)
        {
            //throw new NotImplementedException();
            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> Deleteasync(int id)
        {
            var blog = await _dbContext.Blogs.FirstOrDefaultAsync(model => model.ID == id);
            if (blog == null)
            {
                return 0;
            }
            _dbContext.Remove(blog);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<List<Blog>> GetAllasync()
        {
            return await _dbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIDasync(int id)
        {
            return await _dbContext.Blogs.AsNoTracking().FirstOrDefaultAsync(x=>x.ID == id);
        }

        public async Task<int> Updateasync(int iD, Blog blog)
        {
           var blogs = await _dbContext.Blogs.FirstOrDefaultAsync(x => x.ID == iD);
        if (blogs == null)
            {
                return 0;
            }
            //blogs.ID = blog.ID
            blogs.Name = blog.Name;
            blogs.Description = blog.Description;
            blogs.Author = blog.Author;
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }
}
