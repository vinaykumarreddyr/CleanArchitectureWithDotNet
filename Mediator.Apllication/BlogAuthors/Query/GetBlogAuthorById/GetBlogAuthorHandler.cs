using AutoMapper;
using Mediator.Apllication.BlogAuthor.Query.GetAllBlogAuthors;
using Mediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.BlogAuthor.Query.GetBlogAuthorById
{
    public class GetBlogAuthorHandler : IRequestHandler<GetBlogAuthorQuery, BlogAuthorVM>
    {
        private readonly IBlogAuthorRepository _repository;
        private readonly IMapper _mapper;
        public GetBlogAuthorHandler(IBlogAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BlogAuthorVM> Handle(GetBlogAuthorQuery request,CancellationToken cancellationToken)
        {
            var Blog = await _repository.GetById(request.BlogAuthorId);
            return _mapper.Map<BlogAuthorVM>(Blog);
            
        }
    }
}
