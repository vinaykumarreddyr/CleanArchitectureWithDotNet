using Mediator.Apllication.BlogAuthor.CreateBlogAuthorr;
using Mediator.Domain.Entity;
using Mediator.Domain.Repository;
using MediatR;

//public class CreateBlogWithAuthorHandler : IRequestHandler<CreateBlogWithAuthorCommand, int>

    public class CreateBlogWithAuthorHandler : IRequestHandler<CreateBlogWithAuthorCommand, int>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IBlogAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBlogWithAuthorHandler(
            IBlogRepository blogRepository,
            IBlogAuthorRepository authorRepository,
            IUnitOfWork unitOfWork)
        {
            _blogRepository = blogRepository;
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateBlogWithAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var author = new BlogAuthor { Name = request.AuthorName, IsActive=request.Isactive };
                await _authorRepository.Create(author);
                await _unitOfWork.SaveChangesAsync(cancellationToken); // To get author.Id

            // ❌ Simulate error
            if (author.Name == "fail")
                throw new Exception("Simulated failure after author insert");

            var blog = new Blog { Name = request.BlogName,Description=request.Description, AuthorID = author.AuthorID };
                await _blogRepository.Createasync(blog);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await _unitOfWork.CommitAsync(cancellationToken);
                return blog.ID;
            }
            catch
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }


