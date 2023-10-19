using AutoMapper;
using Explorer.Blog.API.Dtos;

namespace Explorer.Blog.Core.Mappers;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<BlogDto, Domain.Blog>().ReverseMap();
    }
}