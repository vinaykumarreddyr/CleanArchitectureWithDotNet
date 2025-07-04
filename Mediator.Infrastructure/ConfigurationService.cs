using Mediator.Apllication.Blogs.Query.GetallBlogs;
using Mediator.Domain.Repository;
//using Mediator.Infrastructure.Data; // Assuming BlogDbContext is here
using Mediator.Infrastructure.Repository; // Assuming BlogRepository is here
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection; // Don't forget this using for Assembly.GetExecutingAssembly() if you're using it elsewhere

namespace Mediator.Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<BlogDbContext>(options =>
            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ??
                    throw new InvalidOperationException("Connection string 'DefaultConnection' not found")));
            // 2. Register MediatR with the assembly containing GetBlogQueryHandler
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetBlogQueryHandler).Assembly));

            // ⭐⭐⭐ THIS IS THE CRITICAL CHANGE ⭐⭐⭐
            // Move the IBlogRepository registration to be BEFORE the return statement.
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IBlogAuthorRepository, BlogAuthorRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            // 3. Now, return the service collection
            return services;
        }
    }
}