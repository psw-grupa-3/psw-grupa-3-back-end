using AutoMapper;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Core.Converters;
using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;

namespace Explorer.Blog.Core.UseCases
{
    public class BlogService : CrudService<BlogDto, Domain.Blog> ,IBlogService
    {
        public BlogService(ICrudRepository<Domain.Blog> repository, IMapper mapper): base(repository, mapper) { }
        public Result<List<BlogDto>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Result<BlogDto> RateBlog(int blogId, BlogRatingDto rating)
        {
            var ratingDomain = BlogRatingConverter.ToDomain(rating);
            Domain.Blog oldBlog = CrudRepository.Get(blogId);
            oldBlog.Rate(ratingDomain);
            CrudRepository.Update(oldBlog);
            return MapToDto(oldBlog);
        }
    }
}
