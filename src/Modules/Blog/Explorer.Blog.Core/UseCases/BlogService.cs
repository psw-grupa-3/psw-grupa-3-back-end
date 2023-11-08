using AutoMapper;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Core.Converters;
using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Blog.Core.Converters;

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
            var oldBlog = CrudRepository.Get(blogId);
            oldBlog.Rate(ratingDomain);
            CrudRepository.Update(oldBlog);
            return MapToDto(oldBlog);
        }

        public Result<BlogDto> PublishBlog(int blogId)
        {
            var toPublish = CrudRepository.Get(blogId);
            toPublish.PublishBlog();
            CrudRepository.Update(toPublish);
            return MapToDto(toPublish);
        }


        public Result<BlogDto> CommentBlog(int blogId, BlogCommentDto comment)
        {
            var blogComment = BlogCommentConverter.ToDomain(comment);
            Domain.Blog blog = CrudRepository.Get(blogId);
            blog.BlogComments.Add(blogComment);
            CrudRepository.Update(blog);
            return MapToDto(blog);
        }

        public Result<BlogDto> UpdateComment(int blogId, BlogCommentDto comment)
        {
            var blogComment = BlogCommentConverter.ToDomain(comment);
            Domain.Blog blog = CrudRepository.Get(blogId);
            blog.UpdateComments(blogComment);
            CrudRepository.Update(blog);
            return MapToDto(blog);
        }

        public Result<BlogDto> DeleteComment(int blogId, BlogCommentDto comment)
        {
            var blogComment = BlogCommentConverter.ToDomain(comment);
            Domain.Blog blog = CrudRepository.Get(blogId);
            blog.BlogComments.Remove(blogComment);
            CrudRepository.Update(blog);
            return MapToDto(blog);
        }



    }
}
