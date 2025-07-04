using AutoMapper;
using Mediator.Apllication.Blogs.Command.DeleteBlog;
using Mediator.Apllication.Blogs.Query.GetBlogbyID;
using Mediator.Domain.Entity;
using Mediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.Blog_s.Command.UpdateBlog
{
    public class UpdateCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public UpdateCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var updatenetry = new Blog() { ID = request.ID ,Name=request.Name,Description=request.Description};
            var blogupdate =await  _blogRepository.Updateasync(request.ID, updatenetry);
            return blogupdate;
        }
    }
}
