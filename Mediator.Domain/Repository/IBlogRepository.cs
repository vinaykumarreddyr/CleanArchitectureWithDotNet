using Mediator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Domain.Repository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllasync();
        Task<Blog> GetByIDasync(int id);
        Task<Blog> Createasync(Blog blog);
        Task<int> Updateasync(int iD, Blog blog);
        Task<int> Deleteasync(int id);

    }
}
