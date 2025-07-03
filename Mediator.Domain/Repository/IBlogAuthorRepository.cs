using Mediator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Domain.Repository
{
    public interface IBlogAuthorRepository
    {
        Task<List<BlogAuthor>> GetAll();
        Task<BlogAuthor> GetById(int id);
        Task<BlogAuthor> Create(BlogAuthor author);
        Task<int> Update(int id, BlogAuthor author);
        Task<int> Delete(int id);
    }
}
