using AutoMapper;
using Mediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.BlogAuthors.Command.UpdateBlogAuthor
{
    public class UpdateBlogAuthorHandler : IRequestHandler<UpdateBlogAuthorCommand, int>
    {
        private readonly IBlogAuthorRepository _repository;
        private readonly IMapper _mapper;
        public UpdateBlogAuthorHandler(IBlogAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateBlogAuthorCommand command, CancellationToken cancellationToken)
        {
            var updates = new Domain.Entity.BlogAuthor() { AuthorID = command.AuthorID, Name = command.Name, IsActive = command.Isactive };
            var blogupdate = await _repository.Update(command.AuthorID, updates);
            return blogupdate;
        }
    }
}
