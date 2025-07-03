using AutoMapper;
using Mediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.Blog_s.Command.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlgoCommand, int>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public DeleteBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(DeleteBlgoCommand request, CancellationToken cancellationToken)
        {
            return await _blogRepository.Deleteasync(request.ID);
        }
    }
}
