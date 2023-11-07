using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.Core.Domain;

namespace Explorer.Blog.Core.Mappers;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<BlogDto, Domain.Blog>()
            .ForMember(dest => dest.BlogComments, opt => 
                opt.MapFrom(src => 
                    src.BlogComments.Select(x => 
                        new BlogComment(x.UserId, x.BlogId, x.Comment, x.TimeCreated, x.TimeUpdated)))); 
        CreateMap <Domain.Blog, BlogDto>()
            .ForMember(dest => dest.BlogComments, opt => 
                opt.MapFrom(src => 
                    src.BlogComments.Select(x => 
                        new BlogCommentDto() { UserId = (int)x.UserId, BlogId = (int)x.BlogId,  Comment = x.Comment, TimeCreated = x.TimeCreated, TimeUpdated = x.TimeUpdated })));
    }
}