using AutoMapper;
using Mediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.BlogAuthors.Command.DeleteBlogAuthor
{
    public class DeleteBlogAuthorCommandHandler : IRequestHandler<DeleteBlogAuthorCommand ,int>
    {
        private readonly IBlogAuthorRepository _blogAuthorRepository;
        private readonly IMapper _mapper;
        public DeleteBlogAuthorCommandHandler(IBlogAuthorRepository blogAuthorRepository, IMapper mapper)
        {
            _blogAuthorRepository = blogAuthorRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(DeleteBlogAuthorCommand command,CancellationToken cancellationToken)
        {
            return await _blogAuthorRepository.Delete(command.AuthorID);
        }
    }
}
