using AutoMapper;
using Mediator.Domain.Repository;
using MediatR;

namespace Mediator.Apllication.Blogs.Query.GetBlogbyID
{
    public class GetByIdHandler : IRequestHandler<GetByIDQuery, BlogVM>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetByIdHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<BlogVM> Handle(GetByIDQuery request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetByIDasync(request.ID);
            return _mapper.Map<BlogVM>(blog);
        }
    }
}
