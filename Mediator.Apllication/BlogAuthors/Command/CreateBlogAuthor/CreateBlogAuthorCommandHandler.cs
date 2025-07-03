using AutoMapper;
using Mediator.Apllication.BlogAuthor.Query.GetAllBlogAuthors;
using Mediator.Domain.Repository;
using MediatR;
using Mediator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.BlogAuthor.Command.CreateBlogAuthor
{
    public class CreateBlogAuthorCommandHandler : IRequestHandler<CreateBlogAuthorCommand, BlogAuthorVM>
    {
        private readonly IBlogAuthorRepository _repository;
        private readonly IMapper _mapper;
        public CreateBlogAuthorCommandHandler(IBlogAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BlogAuthorVM> Handle(CreateBlogAuthorCommand command, CancellationToken cancellationToken)
        {
            var NewEntry = new Domain.Entity.BlogAuthor() { Name = command.Name, IsActive = command.Isactive };
            await _repository.Create(NewEntry);

            // Then map to VM - no await needed as Map is synchronous
            var result = _mapper.Map<BlogAuthorVM>(NewEntry);

            return result;
        }
    }
}
