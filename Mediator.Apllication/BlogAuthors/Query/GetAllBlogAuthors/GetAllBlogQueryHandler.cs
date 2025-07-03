using AutoMapper;
using Mediator.Domain.Repository;
using MediatR;

namespace Mediator.Apllication.BlogAuthor.Query.GetAllBlogAuthors
{
    public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQuery ,List<BlogAuthorVM>>
    {
        private readonly IBlogAuthorRepository _repository;
        private readonly IMapper _mapper;
        public GetAllBlogQueryHandler(IBlogAuthorRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<BlogAuthorVM>> Handle(GetAllBlogQuery request, CancellationToken cancellationToken)
        {
            var authorblogs = await _repository.GetAll();
            var authorblogslist = _mapper.Map<List<BlogAuthorVM>>(authorblogs);
            return authorblogslist;
        }
    }
}
