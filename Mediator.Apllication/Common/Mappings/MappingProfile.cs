using AutoMapper;
using Mediator.Domain.Entity;
using Mediator.Apllication.BlogAuthor.Query.GetAllBlogAuthors;
using Mediator.Apllication.Blogs.Query.GetBlogbyID;
using System.Reflection;

namespace Mediator.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Explicit mappings
            CreateMap<Blog, BlogVM>();
            CreateMap<BlogAuthor, BlogAuthorVM>().ReverseMap();

            // Automatic mappings from IMapFrom<T> implementations
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping")
                    ?? type.GetInterface("IMapFrom`1")?.GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}