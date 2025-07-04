using Mediator.Apllication.Blog_s.Command.DeleteBlog;
using Mediator.Apllication.BlogAuthor.Command.CreateBlogAuthor;
using Mediator.Apllication.BlogAuthor.CreateBlogAuthorr;
using Mediator.Apllication.BlogAuthor.Query.GetAllBlogAuthors;
using Mediator.Apllication.BlogAuthor.Query.GetBlogAuthorById;
using Mediator.Apllication.BlogAuthors.Command.UpdateBlogAuthor;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecturewithCQRSandmediator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAuthorController : ApiControllerBase
    {
        [HttpPost("create-blog-with-author")]
        public async Task<IActionResult> CreateBlogWithAuthor([FromBody] CreateBlogWithAuthorCommand command)
        {
            var blogId = await Mediator.Send(command);
            return Ok(new { BlogId = blogId });
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await Mediator.Send(new GetAllBlogQuery());
            return Ok(blogs);
        }

        [HttpGet("{id:int}", Name = "GetBlogAuthorById")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetBlogAuthorQuery(id));
            return blog == null ? NotFound() : Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogAuthorCommand command)
        {
            var createdAuthor = await Mediator.Send(command);
            return CreatedAtRoute(
                routeName: "GetBlogAuthorById",
                routeValues: new { id = createdAuthor.AuthorID },
                value: createdAuthor);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateBlogAuthorCommand command)
        {
            if (id != command.AuthorID)
            {
                return BadRequest("ID in URL must match ID in request body");
            }
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteBlgoCommand(id));
            return NoContent();
        }
    }
}