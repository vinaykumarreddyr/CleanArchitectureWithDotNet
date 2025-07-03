using AutoMapper;
using Mediator.Apllication.Blogs.Query.GetBlogbyID;
using Mediator.Domain.Repository;
using MediatR;

namespace Mediator.Apllication.Blogs.Query.GetallBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVM>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetBlogQueryHandler (IBlogRepository blogRepository,IMapper mapper)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
        }
        public async Task<List<BlogVM>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllasync();
            var bloglist = _mapper.Map<List<BlogVM>>(blogs);
            return bloglist;
        }
    }
}
