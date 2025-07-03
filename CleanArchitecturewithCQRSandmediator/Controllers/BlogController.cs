using Mediator.Apllication.Blog_s.Command.DeleteBlog;
using Mediator.Apllication.Blogs.Command.CreateBlog;
using Mediator.Apllication.Blogs.Command.DeleteBlog;
using Mediator.Apllication.Blogs.Query.GetallBlogs;
using Mediator.Apllication.Blogs.Query.GetBlogbyID;
using MediatR; // Correct namespace
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Mediator.Application.Blogk_s.Command.Createasync; // Ensure this namespace is correct for your query

namespace CleanArchitecturewithCQRSandmediator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        private readonly ILogger _logger;
        public BlogController(ILogger<BlogController> logger)
        {
        _logger = logger;
            _logger.LogInformation("Started");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            //_logger.LogTrace("Trace : Entererd into the getallmethod");
            //try
            //{
            //    _logger.LogTrace("Debug Started");
            //    _logger.LogInformation("Information : Performing some operations");
            //    if (DateTime.Now.Microsecond % 2 == 0)
            //    {
            //        _logger.LogWarning("Warning : Unexpected issue");
            //    }
            //    else
            //    {
            //        throw new InvalidOperationException("Error Occured");
            //    }
            //    _logger.LogInformation("Operation executed successfully");
            //    _logger.Log(LogLevel.Information, "Getall method executed");
            //    //return Ok("Success");
            //}
            //catch (Exception ex) {
            //    _logger.LogError(ex, "An error occured");
            //    _logger.LogCritical(ex, "This error is critical");
            //}
            //finally
            //{
            //    _logger.LogTrace("Trace : Exit");
            //}
            _logger.LogTrace("Trace");
            _logger.LogDebug("Debug");
            _logger.LogError("Error");
            _logger.LogCritical("Critical");
            var blogs = await Mediator.Send(new GetBlogQuery());
            _logger.LogInformation("Executing GetAllmethod");
            return Ok(blogs);
        }
        [HttpGet("{ID}")]
        public async Task<IActionResult> GetByIDasync(int ID)
        {
            var blogs = await Mediator.Send(new GetByIDQuery(ID));
            if (blogs == null)
            {
                return NotFound();
            }
            _logger.LogInformation("Executing Get method");
            return Ok(blogs);

        }
        [HttpPost]
        public async Task<IActionResult> Createasync(CreateBlogCommand command)
        {
            var CreatedBlog = await Mediator.Send(command);
            _logger.LogInformation("Executing Create method");
            return CreatedAtAction(nameof(GetByIDasync), new { ID = CreatedBlog.ID }, CreatedBlog);
        }
        [HttpPut("{ID}")]
        public async Task<IActionResult> Updateasync(int ID,UpdateBlogCommand command)
        {
            if (ID != command.ID)
            {
                return BadRequest();
            }
            await Mediator.Send(command);
            _logger.LogInformation("Executing Update method");
            return NoContent();
        }
        [HttpDelete("{ID}")]
        public async Task<IActionResult> Deleteasync(int ID)
        {
            await Mediator.Send(new DeleteBlgoCommand(ID));
            _logger.LogInformation("Executing Delete method");
            return NoContent();
        }
        }
    }