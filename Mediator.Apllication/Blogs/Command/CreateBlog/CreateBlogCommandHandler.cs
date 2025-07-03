using AutoMapper;
using Mediator.Apllication.Blogs.Query.GetBlogbyID;
using Mediator.Domain.Entity;
using Mediator.Domain.Repository;
using MediatR;

namespace Mediator.Apllication.Blogs.Command.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVM>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<BlogVM> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var Entry = new Blog() { Name = request.Name ,Description = request.Description,Author =request.Author};
            var result = await _blogRepository.Createasync(Entry);
            return _mapper.Map<BlogVM>(result);
        }
    }
}
