using AutoMapper;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Blog.Core.Domain.RepositoryInterfaces;

namespace Explorer.Blog.Core.UseCases
{
    public class BlogService : CrudService<BlogDto, Domain.Blog> ,IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(ICrudRepository<Domain.Blog> repository, IMapper mapper, IBlogRepository blogRepository) :
            base(repository, mapper)
        {
            _blogRepository = blogRepository;
        }
    }
}
